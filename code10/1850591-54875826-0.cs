    // Iterate through the alive array
    // If the cell at that position is alive...
    if (alive[x][y] == true)
    {
        for (X = -1; X <= 1; X++)
        {
            for (Y = -1; Y <= 1; Y++)
            {
                // Get the coordinates of the positions around it
                dx = x + X;
                dy = y + Y;
                // If the coordinates are valid
                if (dx >= 0 && dy >= 0 && dx < ROW && dy < COLUMN)
                {
                    // Increment the neighbour array
                    neighbours[dx][dy] += 1;
                }
            }
        }
    }
