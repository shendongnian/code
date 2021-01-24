    void OnMouseDown()
    {
        int index = GameObjectToIndex(gameObject);
        Debug.Log(index);
    }
    
    int GameObjectToIndex(GameObject targetObj)
    {
        //Loop through GameObjects
        for (int i = 0; i < Objects.Count; i++)
        {
            //Check if GameObject is in the List
            if (Objects[i] == targetObj)
            {
                //It is. Return the current index
                return i;
            }
        }
        //It is not in the List. Return -1
        return -1;
    }
