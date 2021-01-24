    public CharacterController controller;
 
	private float verticalVelocity;
	private float gravity = 25.0f;
	private float jumpForce = 15.0f;
 
	void Awake () {
		controller = GetComponent<CharacterController>();
 	}
	void Update () {
		 
		if( controller == null )
			return;
		
		if( controller.isGrounded)
		{
			verticalVelocity = -gravity * Time.deltaTime;
			if( Input.GetKeyDown(KeyCode.Space) )
			{
				verticalVelocity = jumpForce;
			}
		}
		else
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical"); 	
		Vector3 moveVector = Vector3.zero;
		moveVector.x = moveHorizontal * 5.0f;
		moveVector.y = verticalVelocity;
		moveVector.z = moveVertical * 5.0f;
		controller.Move(moveVector * Time.deltaTime);
	} 
