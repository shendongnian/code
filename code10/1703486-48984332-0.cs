    public GameObject yourPrefabRef;
    
    public void CreateObjects(int count)
    {
        while(count--)
        {
           GameObject newObject = Instantiate (yourPrefabRef);
           newObject.transform.position = someFunction();
        }
    }
