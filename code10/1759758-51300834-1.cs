    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            Vector3 movement;
            if (mouse.y > Tucan.transform.position.y)
            {
                movement = Vector3.up;
            }
            else
            {
                movement = Vector3.down;
            }
    
    
            Tucan.GetComponent<Rigidbody2D>().velocity = movement * speed;
        }
    }
