      for (int y = 0; y < numOfCells; ++y)
      {
        g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
      }
      for (int x = 0; x < numOfCells; ++x)
      {
        g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
      }
