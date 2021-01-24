    List<GameObject> gos = new List<GameObject>();
    void CreateObjects()
    {
        if (amountOfObjects > amountCopy && amountCopy != amountOfObjects)
        {
            for (int i = 0; i < amountOfObjects; i++)
            {
                GameObject go = Instantiate(prefabToDraw);
                gos.Add(go);
            }
            amountCopy = amountOfObjects;
        }
    }
