    private void FixedUpdate()
    {
    	float moveHorizontal = Input.GetAxis("Horizontal") * speed;
    	moveHorizontal *= Time.deltaTime;
    
    	grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    
    	if (grounded && Input.GetKeyDown("space"))
    	{
    		rb2d.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    	}
    
    	Vector2 move = new Vector2(moveHorizontal, 0);
    	transform.Translate(move);
    }
