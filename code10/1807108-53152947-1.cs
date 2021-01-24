    public interface IDrawable
    {
        void Draw(Graphics g);
    }
    public class AquaCircle : IDrawable
    {
        void IDrawable.Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Aqua, 1), 1, 1, 100, 100);
        }
    }
    public class RedCircle : IDrawable
    {
        void IDrawable.Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Red, 1), 25, 25, 100, 100);
        }
    }
