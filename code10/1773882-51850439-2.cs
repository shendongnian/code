    using UnityEngine;
    public class Player : MonoBehaviour
    {
        //Components on Player GameObject
        private Rigidbody2D myRigidbody;
        private Animator myAnimator;
    
        //Movement variables
        [SerializeField]
        private float movementSpeed = 9; //Set default values so you don't always
        [SerializeField]                //have to remember to set them in the inspector
        private float jumpForce = 15;
    
        //Ground checking
        [SerializeField]
        private Transform groundPoint;
        [SerializeField]
        private float groundRadius = 0.1f;
        [SerializeField]
        private LayerMask whatIsGround;
    
        private float velocityX;
        private bool isGrounded;
        private bool facingRight;
    
        // Use this for initialization
        private void Start()
        {
            facingRight = true;
            myRigidbody = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
        }
    
        private void Update()
        {
            Flip();
            HandleInput();
            HandleAnimations();
        }
    
        private void FixedUpdate()
        {                       
            HandleMovement();  //It's generally considered good practice to 
                               //call physics-related methods in FixedUpdate
        }
    
        private void HandleAnimations()
        {
            if (!isGrounded)
            {
                myAnimator.SetBool("isGrounded", false);
                //Set the animator velocity equal to 1 * the vertical direction in which the player is moving 
                myAnimator.SetFloat("velocityY", 1 * Mathf.Sign(myRigidbody.velocity.y));
            }
    
            if (isGrounded)
            {
                myAnimator.SetBool("isGrounded", true);
                myAnimator.SetFloat("velocityY", 0);
            }
        }
    
        private void HandleMovement()
        {
            isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, whatIsGround);
    
            velocityX = Input.GetAxis("Horizontal");
    
            myRigidbody.velocity = new Vector2(velocityX * movementSpeed , myRigidbody.velocity.y);
        }
    
        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    
        private void Jump()
        {
            if (isGrounded)
            {   //ForceMode2D.Impulse is useful if Jump() is called using GetKeyDown
                myRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else 
            {
                return;
            }       
        }
    
        private void Flip()
        {
            if (velocityX > 0 && !facingRight || velocityX < 0 && facingRight)
            {
                facingRight = !facingRight;
    
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
    }
