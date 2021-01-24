        for (int curRange = 1; curRange < range + 1; curRange++)
        {
            for (int dy = -curRange; dy < curRange + 1; dy++)
            {
                for (int dz = -curRange; dz < curRange + 1; dz++)
                {
                    for (int dx = -curRange; dx < curRange + 1; dx++)
                    {
                        HexCell neighborHex = GetCellFromCoord(x + (float)dx, y + (float)dy, z + (float)dz);
                        if (neighborHex == null)
                        {
                            continue;
                        }
                        else if (x == neighborHex.coordinates.X && 
                            y == neighborHex.coordinates.Y && 
                            z == neighborHex.coordinates.Z)
                        {
                            continue;
                        }
                        else
                        {
                            if (hexWithinRange.Contains(neighborHex))
                            {
                                continue;
                            }
                            else
                            {
                                hexWithinRange.Add(neighborHex);
                            }
                        }
                    }
                }
            }
        }
