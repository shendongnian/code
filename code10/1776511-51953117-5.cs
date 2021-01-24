    public void checkComputer()
    {
        if (Variab == 0 && whoseTurn == 1)
        {
            //Get Valid indexes
            List<int> validSpacesIndexes = GetValidSpacesIndexes();
            //Geneate Random number within valid Indexes
            int rand = Random.Range(0, validSpacesIndexes.Count);
            //Get the index value
            rand = markedSpaces[rand];
    
            TicTacToeButton(rand);
        }
    }
