    public class MyLabel : System.Windows.Forms.Label
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            // or leave base out
            // you would determine these values by the length of the text
            e.Graphics.DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Red), 
                                   0, 0, 50, 12);
        }
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            // although a label has a KeyDown event I don't know how it would 
            // receive focus, maybe you should create a text box that looks
            // like a label
        }
    }
