    public abstract class Shapes
    {
        // ...
        // abstract method to draw the shape
        public abstract void drawShape(Graphics g);
    } // end of Shapes
    // class Circle derives from Shapes
    public class Circle : Shapes
    {
        // ...
        public override void drawShape(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Green), x1, y1, x2, y2);
        }
    }
    public class Rectangle : Shapes
    {
        // ...
        public override void drawShape(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Green), x1, y1, x2, y2);
        }
    }
