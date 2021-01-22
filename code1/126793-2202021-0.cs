    public NietzscheBattleshipsGameModel()
    {
        HomeArray = new Cell[MAXCOL, MAXROW];
        AwayArray = new Cell[MAXCOL, MAXROW];
    
        for (int i = 0; i < MAXROW; i++)
        {
            for (int j = 0; j < MAXCOL; j++)
            {
                HomeArray[i,j] = new Cell();
                AwayArray[i,j] = new Cell();
            }
        }
    }
