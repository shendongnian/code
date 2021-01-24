    if (Input.GetMouseButtonDown(0))
    {
        /// Check if it's almost idle
        if (rb.velocity.magnitude < 0.05f)
        {
            /// Move it 
            rb.AddForce(20000 * Time.deltaTime, 0, 0);
        } 
        else 
        {
            Debug.Log("Still moving");
        }
    }
