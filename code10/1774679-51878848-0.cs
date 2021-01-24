    GameObject[] ExistingObjects = GameObject.FindGameObjectsWithTag("Parts");
    Vector3[] ObjectPositions = new Vector3[ExistingObjects.Length]
    
    for(int i = 0; i < ObjectPositions.Length; i++)
    {
       ObjectPositions[i] = ExistingObjects[i].transform.position;
       ObjectPositions[i].y = 0;
    }
