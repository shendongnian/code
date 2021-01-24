    int Space = 20;
    public GameObject prefab;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Instantiate 20 prefabs
            for (int i = 0; i < Space; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.transform.position = new Vector3(0, 0, 0);
            }
        }
    }
