    void DestroySomeObjects(int amountFromRightSide)
    {
        if (gos.Count != 0)
            {
                for (int i = gos.Count-1; i <= gos.Count-amountFromRightSide; i--)
                {
                    DestroyImmediate(gos[i]);
                }
            } 
    }
    void DestroyAllObjects()
    {
        if (gos.Count != 0)
            {
                foreach (GameObject go in gos)
                {
                    DestroyImmediate(go);
                }
            } 
    }
