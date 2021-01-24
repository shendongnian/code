    List<int> GetValidSpacesIndexes()
    {
        List<int> markedSpacesIndexes = new List<int>();
    
        //Loop through the markedSpaces 
        for (int i = 0; i < 8; i++)
        {
            //Get indexes with 1 or 2 values
            if (markedSpaces[i] == 1 || markedSpaces[i] == 2)
            {
                markedSpacesIndexes.Add(i);
            }
        }
        return markedSpacesIndexes;
    }
