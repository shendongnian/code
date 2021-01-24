        using System;
    
    abstract class TwoDShape
    {
        double pri_width;
        double pri_height;
        // A default constructor.
        public TwoDShape()
        {
            Width = Height = 0.0;
            name = "null";
        }
        // Parameterized constructor.
        public TwoDShape(double w, double h, string n)
        {
            Width = w;
            Height = h;
            name = n;
        }
        // Construct object with equal width and height.
        public TwoDShape(double x, string n)
        {
            Width = Height = x;
            name = n;
        }
        // Construct a copy of a TwoDShape object.
        public TwoDShape(TwoDShape ob)
        {
            Width = ob.Width;
            Height = ob.Height;
            name = ob.name;
        }
    }
    Class Rectangle:TwoDShape
    {
    public Rectangle(double w, double h) : base(w, h)
    {
    }
    }
