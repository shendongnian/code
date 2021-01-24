    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Camera.main.transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }
