    BitArray maze = null;
    int mazeWidth = 999;
    int mazeHeight = 999;
    int xPos = 0;
    int yPos = 0;
    int cellSize = 10;
    private void Form1_Load(object sender, EventArgs e)
    {
        maze = new BitArray(mazeWidth * mazeHeight);
        Random rnd = new Random();
        for (int i = 0; i < maze.Length; ++i)
        {
            maze[i] = rnd.Next(4) == 0;
        }
        xPos = -Width / 2;
        yPos = -Height / 2;
        DoubleBuffered = true;
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        for (int y = Math.Max(0, yPos / cellSize); y < mazeHeight; ++y)
        {
            int yDraw = y * cellSize - yPos;
            if (yDraw > Height) { return; }
            for (int x = Math.Max(0, xPos / cellSize); x < mazeWidth; ++x)
            {
                if (maze[x + y * mazeWidth])
                {
                    int xDraw = x * cellSize - xPos;
                    if (xDraw > Width) { break; }
                    e.Graphics.FillRectangle(
                        Brushes.Black,
                        xDraw,
                        yDraw,
                        cellSize,
                        cellSize
                        );
                }
            }
        }
    }
    public static int Clamp(int value, int min, int max)
    {
        if (value < min) { return min; }
        if (value > max) { return max; }
        return value;
    }
    int fromX;
    int fromY;
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        fromX = e.X;
        fromY = e.Y;
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            int w2 = Width / 2;
            int h2 = Height / 2;
            xPos = Clamp(xPos + fromX - e.X, -w2, mazeWidth * cellSize - w2);
            yPos = Clamp(yPos + fromY - e.Y, -h2, mazeHeight * cellSize - h2);
            fromX = e.X;
            fromY = e.Y;
            Invalidate();
        }
    }
