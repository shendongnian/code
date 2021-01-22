    List<Creature>[,] theWorld;
    public Environment()
    { 
        theWorld = new List<Creature>[100,100]; // Remove the type, you were creating a new list and throwing it away...
    }
    public void addCreature(Creature c)
    {
       for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 100; y++)
            {
                theWorld[x, y].Add (c);
            } } }
