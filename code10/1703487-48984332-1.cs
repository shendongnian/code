    public GameObject yourPrefabRef;
    
    public void CreateObjects(int objectCount)
    {
        for (int count = 0; count < objectCount; count++)
        {
           GameObject newObject = Instantiate (yourPrefabRef);
           newObject.transform.position = someFunction();
        }
    }
