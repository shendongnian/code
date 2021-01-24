    List<GameObject> MediumAreas = new List<GameObject>();
    
    void DefineMediumAreas()
    {
        GameObject areaContainer = GameObject.Find("areaContainer");
        foreach (Transform thisObject in areaContainer.transform)
        {
            //Check if it contains area
            if (thisObject.name.StartsWith("area"))
            {
                //Add to MediumAreas List
                MediumAreas.Add(thisObject.gameObject);
            }
        }
    }
