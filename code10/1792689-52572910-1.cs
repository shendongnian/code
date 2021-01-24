    internal class Key : CollisionTrigger
    {
    	public override void FakeOnTriggerStay()
        {
    		// Show the user they can now interact with it.
    		// Outline Shader maybe?
    	
            if(Input.GetKeyDown(KeyCode.E))
            {
                // Do something with the key.
            }
        }
    }
