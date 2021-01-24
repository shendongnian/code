    public float speed = 100.0f;
    
    void Update()
    {
        if (true)
        {
            foreach (GameObject move in spawning)
            {
                //Get Rigidbody component 
                Rigidbody rb = move.GetComponent<Rigidbody>();
                //Calculate Z-axis pos to move to
                Vector3 pos = new Vector3(0, 0, 1);
                pos = pos.normalized * speed * Time.deltaTime;
                //Move with Rigidbody
                rb.MovePosition(rb.transform.position + pos);
            }
        }
    }
