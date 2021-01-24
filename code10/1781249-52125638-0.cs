    void playerWalk()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 75f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 15f;
        if (Input.GetKeyDown(KeyCode.S))
        {
            // If "S" is pressed, the z speed would be reduced to 5f.
            z = Input.GetAxis("Vertical") * Time.deltaTime * 5f; 
        }
    
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, -z);
    }
