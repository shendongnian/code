    class Rectangle
    {
       private readonly _width;
       private readonly _height;
       
       public Rectangle(int width, int height)
       {
          _width = width;
          _height = height;
       }
       public int Width { get { return _width; } }
       public int Height { get { return _height; } }
    }
