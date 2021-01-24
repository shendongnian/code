    // If the cell is alive...
    if (alive[x][y] == true)
    {
        // Remove the bias (the UpdateNeighbour function adds neighbour in a 3x3 area, not only the neighbours.)
        numNeighbours -= 1;
        // If it has less than 2 neighbours...
        if (numNeighbours < 2)
        {
            // It dies
            alive[i][y] = false;
        }
        // If it has 2 or 3 neighbours...
        else if(numNeighbours < 4)
        {
            // It survives
            alive[i][y] = true;
        }
        // If it has more than 4 neighbours...
        else if (numNeighbours >= 4)
        {
            // It dies
            alive[i][y] = false;
        }
    }
    // If the cell isn't alive but has exactly 3 neighbours...
    else if (alive[x][y] == false && numNeighbours == 3)
    {
        // Spawn new cell
        alive[x][y] = true;
    }
