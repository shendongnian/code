    private KeyCode lastKeyPressed;
    private Vector3 vector;
    
    private void Update ()
    {
        bool w, a, s, d;
        w = Input.GetKeyDown(KeyCode.W);
        a = Input.GetKeyDown(KeyCode.A);
        s = Input.GetKeyDown(KeyCode.S);
        d = Input.GetKeyDown(KeyCode.D);  
    
        if (w)
        {
            lastKeyPressed = KeyCode.W;
            vector = new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
        }
        else if (a)
        {
            lastKeyPressed = KeyCode.A;
            vector = new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (s)
        {
            lastKeyPressed = KeyCode.S;
            vector = new Vector3(0.0f, -speed * Time.deltaTime, 0.0f);
        }
        else if (d)
        {
            lastKeyPressed = KeyCode.D;
            vector = new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }
    
        if(Input.GetKey(lastKeyPressed))
        {
            transform.Translate(vector);
        }
    }
