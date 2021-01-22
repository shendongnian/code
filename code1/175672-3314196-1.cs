    public abstract class Shape
    {
        // ...
        // abstract method to draw the shape
        public abstract void DrawShape(Graphics g);
    } // end of Shape
    // class Circle derives from Shape
    public class Circle : Shape
    {
        // ...
        public override void DrawShape(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Green), x1, y1, x2, y2);
        }
    }
    public class Rectangle : Shape
    {
        // ...
        public override void DrawShape(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Green), x1, y1, x2, y2);
        }
    }
