    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //notice the removing of the ;
        {
            GetComponent<PlayerMov>().enabled = true;
        }
    }
