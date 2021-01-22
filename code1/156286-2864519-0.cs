    public class CursorBase : UserControl
    {
        public virtual void MoveTo(Point pt)
        {
            this.SetValue(Canvas.LeftProperty, pt.X);
            this.SetValue(Canvas.TopProperty, pt.Y);
        }
    }
