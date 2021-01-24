    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TheBot : MonoBehaviour {
    
    	public float speed;
    	public int jumpForce;
    	public Transform groundCheck;
    	public Transform meleeCheck;
    	public Transform bulletSpawner;
    	public LayerMask layerGround;
    	public float meleeCoolDown;
    	public float meleeDamage;
    
    	private Rigidbody2D body;
    	private Animator anim;
    	private Dash dashController;
    	private Shooter shotController;
    	private float unloadWaitingTime = 3;
    	private float idleGunTime = 0;
    
    	private bool facingRight = true;
    	private bool onGround = true;
    	private bool jumping = false;
    	private bool attacking = false;
    	private bool dead = false;
    	private bool isGunLoaded = false;
    	private bool isGunLoading = false;
    	private bool isGunUnloading = false;
    	private bool takingDamage = false;
    	private bool dashing = false;
    	private bool isWallSliding = false;
    
    	private float wallJumpTime = 0f;
    	private Vector3[] wallJumpControlPoint;
    
    	// Use this for initialization
    	void Start () {
    		body = GetComponent<Rigidbody2D>();
    		anim = GetComponent<Animator>();
    		dashController = GetComponent<Dash>();
    		shotController = GetComponent<Shooter>();
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		PlayAnimations();
    		CheckIfGrounded();
    		checkIfWallSliding();
    		dashing = dashController.IsDashing();
    
    		if (Input.GetButtonDown("Jump") && (onGround || isWallSliding)  && !isGunLoading && !jumping && !takingDamage){
    			jumping = true;
    			wallJumpControlPoint = new Vector3[3];
    			wallJumpControlPoint[0] = body.position;
    			wallJumpControlPoint[1] = new Vector3(body.position.x +4, body.position.y + 2);
    			wallJumpControlPoint[2] = new Vector3(body.position.x, body.position.y + 4);
    		}
    		if (Input.GetButtonDown("Melee") && !attacking && !isGunLoading){
    			Attack();
    		}
    		if(Input.GetButtonDown("Ranged") && !attacking  && !isGunLoading && onGround){
    			Shoot();
    		}
    
    		if(Input.GetButtonDown("Dash") && !attacking && !isGunLoading && onGround){
    			dashController.DashTo(facingRight? Dash.RIGHT : Dash.LEFT);
    		}
    
    
    		if(isGunLoaded){
    			idleGunTime += Time.deltaTime;
    			if (idleGunTime >= unloadWaitingTime){
    				UnloadGun();
    			}
    		}
    
    	}
    
    	void FixedUpdate(){
    		if(!takingDamage){
    
    			float move = Input.GetAxis("Horizontal");
    
    			//while charachter is wall sliding, slowly fall
    			if (isWallSliding && body.velocity.y < -0.7f){ 
                    body.velocity = new Vector2(body.velocity.x, -0.7f)
    			}
    			
                if(!dashing){
                    if(onGround){
                        //if not dashing on on ground, walk with normal speed
                        body.velocity = new Vector2(move * speed, body.velocity.y);
                    } else {
                        //if character is not on ground, reduce the speed so he doesn't jump too far away
                        float airControlAccelerationLimit = 0.5f;  // Higher = more responsive air control
                        float airSpeedModifier = 0.7f; // the 0.7f in your code, affects max air speed
                        float targetHorizVelocity = move 
                                * speed 
                                * airSpeedModifier;  // How fast we are trying to move horizontally
                        float targetHorizChange = targetHorizVelocity 
                                - body.velocity.x; // How much we want to change the horizontal velocity
                        float horizChange = Mathf.Clamp(
                                targetHorizChange ,
                                -airControlAccelerationLimit , 
                                airControlAccelerationLimit ); // How much we are limiting ourselves 
                                                               // to changing the horizontal velocity
                        body.velocity = new Vector2(body.velocity.x + horizChange, body.velocity.y);
                    }
                }
    			if((move < 0 && facingRight) || (move > 0 && !facingRight) ){
    				//control direction character is facing
    				Flip();
    			}
    
    			if (jumping){
    				
    				if(isWallSliding){
    					body.velocity = new Vector2(body.velocity.x, 0);
                        body.AddForce(new Vector2(0.25 * jumpForce, jumpForce), ForceMode2D.Impulse);
    				} else {
    					body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    				}
    
    				if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)){
    					//if is moving while jumping, reduce jump height
    					body.velocity = new Vector2(body.velocity.x, body.velocity.y*0.8f);
    				}
    				onGround = false;
    				jumping = false;
    			} 		
    		}
    	}
    
    	void CheckIfGrounded(){
    		onGround = false;
    		Collider2D[] collisionResults = new Collider2D[2];
    		int objectsBeneath = Physics2D.OverlapBoxNonAlloc(groundCheck.position, new Vector2(0.9f, 0.3f), 0.0f, collisionResults, layerGround);
    		for (int i=0; i <objectsBeneath; i++ ){
    			if (!GameObject.ReferenceEquals(gameObject, collisionResults[i].gameObject)){
    				onGround = true;
    			}
    		}
    	}
    
    	void checkIfWallSliding(){
    		if (!onGround){
    			RaycastHit2D[] ray = new RaycastHit2D[1];
    			int totalRayHits = Physics2D.LinecastNonAlloc(bulletSpawner.position, body.position, ray, 1 << LayerMask.NameToLayer("SolidGround"));
    			bool wallFound = totalRayHits > 0 && ray[0].collider.gameObject.tag == "SolidGround";
    
    			isWallSliding = wallFound && ( (facingRight && Input.GetKey(KeyCode.RightArrow)) ||  (!facingRight && Input.GetKey(KeyCode.LeftArrow))) ;
    		} else {
    			isWallSliding = false;
    		}
    	}
    
    
    	public void Die(){
    		dead = true;
    	}
    
    }
