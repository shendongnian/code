	int delay = 6 * ticksPerSecond; // ticks to delay for
    int cooldown = 0;
    public void loop()
	{
		if (currentKeyState.IsKeyDown(Keys.Space))
		{
		    if(cooldown <= 0)
		    { 
		          Shoot();
		          cooldown = delay
	        }
		}
		UpdateLasers(graphics);
		if(cooldown > 0){
		      cooldown -= 1;
		}
	}
