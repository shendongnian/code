    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Camera.main.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
