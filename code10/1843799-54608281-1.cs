    bool aremoving;
    void LateUpdate()
    {
        GameObject[] Cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject Cube in Cubes)
        {
            if (Cube.GetComponent<Rigidbody>() == null)
            {
                continue;
            }
            if (Cube.GetComponent<Rigidbody>().velocity.magnitude > 0.01f)
            {
                aremoving = true;
            }
        Debug.Log("Cubes moving: " + aremoving);
        aremoving  = false; 
    }
