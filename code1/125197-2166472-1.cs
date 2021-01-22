    class Rectangle
    {
       private readonly int _width;
       private readonly int _height;
       
       public Rectangle(int width, int height)
       {
          _width = width;
          _height = height;
       }
       public int Width { get { return _width; } }
       public int Height { get { return _height; } }
    }
