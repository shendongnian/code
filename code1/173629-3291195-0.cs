    public class MyCustomPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            e.Graphics.Clear(Color.Red);
        }
    }
