    // Using a property will always return the targets X value when called without having to 
    // set it to a variable
    private float X 
    { 
        // Called when getting value of X
        get { return Rigidbody2d.transform.position.X; } }  
        // Called when setting the value of X
        set { transform.position = new Vector2(value, transform.position.y); }  
    }
    private bool isMoving = false;
    private void Update () 
    {  
        
        if (X < -4 && !isMoving)
        { 
            Rigidbody2d.velocity = new Vector2(1f, 0f); // Move plank till it reaches point B
            isMoving = true;
        }
        else if (isMoving) 
        { 
            Rigidbody2d.velocity = new Vector(0f, 0f);  // You probably want to reset the 
                                                        // velocity back to 0
            isMoving = false;
        }                                               
    } 
