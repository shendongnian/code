    HexCell getHexCellFromCoordinate(int x, int y, int z)
    {
        return cells.FirstOrDefault(
            cell =>
               cell.x == x &&
               cell.y == y &&
               cell.z == z
        );
    }
    HexCell getHexCellFromCoordinate(Vector3Int coord)
    {
        return cells.FirstOrDefault(cell =>
             cell.x == coord.x &&
             cell.y == coord.y &&
             cell.z == coord.z
        );
    }
