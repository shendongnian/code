    public class Program
    {
        // These are C# get-only properties
        // They cannot be assigned a value
        double StartX => algPosition.X;    // Body is called each time the member is read
        double StartY => algPosition.Y;    // Which gives the most up-to-date values 
    }
    ...
    
    algPosition = GetPosition();
    double offset_SourceX = _vertex.Point.X - StartX;
    double offset_SourceY = _vertex.Point.Y - StartY;
    Point position = new Point(algPosition.X + offset_SourceX, algPosition.Y + offset_SourceY);
