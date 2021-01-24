    List<Object>[,] _grid2D = new List<Object>[20, 20];
    Random rand = new Random();
    for (int i = 0; i < 10; i++)
    {
        int x = rand.Next(1, 20);
        int y = rand.Next(1, 19);
        Object obj = new object(); // Replace with your InsertObject here.
        if (_grid2D[x, y] == null) // If this cell's list doesn't exist yet...
        {
            _grid2D[x, y] = new List<Object>(); /// ... then make one.
        }
        _grid2D[x, y].Add(obj); // Add the object to the list.
    }
