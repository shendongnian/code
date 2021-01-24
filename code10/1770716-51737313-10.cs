    public class FillObject
    {
       public FillObject(int width, Color color)
       {
          Width = width;
          Color = color.ToArgb();
       }
    
       public int Color { get; set; }
    
       public int Width { get; set; }
    }
