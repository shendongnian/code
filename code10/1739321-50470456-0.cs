    List<Vector3> vectorList = new List<Vector3>();
    void TaskOnClick()
    {
        Fill();
        instantiatedObjects = instantiatedObjects.OrderBy(Sphere => Sphere.name).ToList();
        for(int i = 0; i < instanciatedObjects.Count; i++)
        {
            instantiatedObjects[i].transform.position = vectorList[i];
        }
    }
    
    public void Fill()
    {
        vectorList.Clear();
        instantiatedObjects = new List<GameObject>();
        for (int i = 0; i < deck.Length; i++)
        {
            GameObject spawnedObject = Instantiate(deck[i]) as GameObject;
            instantiatedObjects.Add(spawnedObject);
            vectorList.Add(spawnedObject.transform.position);
        }
    }
