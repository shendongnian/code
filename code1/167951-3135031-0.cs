    public class Form1
    {
       protected override void OnPaint(PaintEventArgs e)
       {
          base.OnPaint(e);
          e.Graphics.DrawString("MyString", new Font("Comic Sans MS", 12.0f), new SolidBrush(Color.Red), new PointF(50.0f, 50.0f));
       }
    }
