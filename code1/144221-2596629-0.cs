    private static void RenderCell(PaintEventArgs e, int cellSize, int y, int x, MazeWall wall, Pen pen)
    {
        if (wall.Direction == MazeWallOrientation.Horisontal)
        {
            e.Graphics.DrawLine(pen,
                x * cellSize,
                y * cellSize + cellSize,
                x * cellSize + cellSize,
                y * cellSize + cellSize
            );
        }
        else
        {
            e.Graphics.DrawLine(pen,
                x * cellSize + cellSize,
                y * cellSize,
                x * cellSize + cellSize,
                y * cellSize + cellSize
            );
        }
    }
