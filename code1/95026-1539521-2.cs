    public class PenHelper : IDisposable
    {
         private readonly Brush _brush;
         public PenHelper(Color color)
         {
             _brush = new SolidBrush(color);
         }
         public Pen CreatePen()
         {
             return new Pen(_brush);
         }
         public void Dispose()
         {
             _brush.Dispose();
         }
    }
