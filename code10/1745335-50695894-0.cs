    const int maxIterations = 60;
    int collideIteration = 0;
    bool collided = false;
    
    public void RunSimulation()
    {
        //RESET OLD VALUES
        collided = false;
        collideIteration = 0;
    
        Physics.autoSimulation = false;
    
        Rigidbody rbdy = GetComponent<Rigidbody>();
        rbdy.AddForce(new Vector3(200.0f, 0.0f, 200.0f));
    
    
        for (int i = 0; i < maxIterations; i++)
        {
            Physics.Simulate(0.02f);
    
            //Check if collided then break out of the loop 
            if (collided)
            {
                collideIteration = i;
    
                print(i);
                break;
            }
        }
        Physics.autoSimulation = true;
    }
    
    public int GetCollideIteration()
    {
        return collideIteration;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        collided = true;
        Debug.Log("Collision: " + collision.collider.name);
    }
