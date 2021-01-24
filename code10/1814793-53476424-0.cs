    bool walking = false;
    
    void FixedUpdate ()
    {
    	// Animate the player.
    	Animating();
    }
    
    void Animating (float h, float v)
    {
    	if (Mathf.Abs(player.velocity.x) > 0  && onFloor==true)
        {
    		walking = true;
        }
        else if(Mathf.Abs(player.velocity.x) == 0  && onFloor==true)
        {
    		walking = false;
        }
    
    	// Tell the animator whether or not the player is walking.
    	anim.SetBool ("IsWalking", walking);
    }
