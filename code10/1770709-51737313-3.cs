    public class FillObject
    {
       public int Width { get; set; }
    
       public int Color { get; set; }
    
       public FillObject(int width, Color color)
       {
          Width = width;
          Color = color.ToArgb();
       }
    }
    
    private static readonly Random _rand = new Random();
    
    private static List<FillObject> _objects = Enumerable.Range(0, _rand.Next(5))
                                                       .Select((i, i1) => new FillObject(_rand.Next(1, 5), _rand.NextColor()))
                                                       .ToList();
    
    private static int _largest;
