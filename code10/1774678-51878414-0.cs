    GameObject[] ExistingObjects = GameObject.FindGameObjectsWithTag("Parts");
    float CountObjects = ExistingObjects.Length;
    List<ObjectPositions> Vector3 = new List<ObjectPositions>();
    for (int i = 0; i < CountObjects; i++)
    {
        float ObjectPositionX = ExistingObjects[i].transform.position.x;
        float ObjectPositionZ = ExistingObjects[i].transform.position.z;
        Vector3.Add(new Vector3(ObjectPositionX, 0, ObjectPositionZ));
    }
