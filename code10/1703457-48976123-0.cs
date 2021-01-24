    public GameObject whole;
    public GameObject TrackRb;
    
    public void moveChildren()
    {
        int i = 0;
    
        //List to hold all child obj
        List<Transform> allChildren = new List<Transform>();
    
        //Find all child obj and store to that List
        foreach (Transform child in whole.transform)
        {
            foreach (Transform tile in child)
            {
                //Make sure the Tile component is attached to the child before using it
                if (tile.GetComponent<Tile>() != null)
                {
                    allChildren.Add(tile);
                    i += 1;
                }
            }
        }
    
        //Now Move them into the TrackRb
        foreach (Transform child in allChildren)
        {
            child.SetParent(TrackRb.transform);
        }
    
        Debug.Log(i);
    }
