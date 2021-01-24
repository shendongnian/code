    var yLength = enemyGrid.grid[0].Length;
    var xLength = enemyGrid.grid.Length;
    spawnablePosition.Add(Vector2.left,  Enumerable.Range(1, yLength).Select(y => new Vector2(0, y)).ToArray());            
    spawnablePosition.Add(Vector2.right, Enumerable.Range(1, yLength).Select(y => new Vector2(xLength - 1, y)).ToArray());            
    spawnablePosition.Add(Vector2.up,    Enumerable.Range(1, xLength).Select(x => new Vector2(x, 0)).ToArray());            
    spawnablePosition.Add(Vector2.down,  Enumerable.Range(1, xLength).Select(x => new Vector2(x, yLength - 1)).ToArray());
