    public class Tetromino 
    {
    // Block is composed of a Point called Position and the color
    public Block[] Blocks { get; protected internal set; }
    // Constructors, etc.
    // Rotate the tetromino by 90 degrees, clock-wise
    public void Rotate() 
    {
        Point middle = Blocks[0].Position;
        List<Point> rel = new List<Point>();
        foreach (Block b in Blocks)
            rel.Add(new Point(b.Position.x - middle.x, b.Position.y - middle.y));
        List<Block> shape = new List<Block>();
        foreach (Point p in rel)
            shape.Add(new Block(middle.x - p.y, middle.y + p.x));
        Blocks = shape.ToArray();
    }
    }
