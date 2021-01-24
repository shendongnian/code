    bool xzEquals(Vector3 pos1, Vector3 pos2)
    {
        return (Mathf.Approximately(pos1.x, pos2.x)
            && Mathf.Approximately(pos1.z, pos2.z));
    }
    
    string GetTagFromPos(float x, float z)
    {
        Vector3 pos = new Vector3(x, 0, z);
    
        rootGameObjects.Clear();
        childObjs.Clear();
    
        GetAllRootObject();
        GetAllChildObjs();
    
        //Loop through all Objects
        for (int i = 0; i < childObjs.Count; i++)
            //check  if x and z matches then return tag
            if (xzEquals(childObjs[i].position, pos))
                return childObjs[i].tag;
    
        return null;
    }
    GameObject GetObjectFromPos(float x, float z)
    {
        Vector3 pos = new Vector3(x, 0, z);
    
        rootGameObjects.Clear();
        childObjs.Clear();
    
        GetAllRootObject();
        GetAllChildObjs();
    
        //Loop through all Objects
        for (int i = 0; i < childObjs.Count; i++)
            //check  if x and z matches then return the Object
            if (xzEquals(childObjs[i].position, pos))
                return childObjs[i].gameObject;
    
        return null;
    }
