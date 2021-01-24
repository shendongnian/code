    public class MyTextBox1 : MyTextBox
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {            
            base.OnMouseClick(e);
            BackColor = Color.Green;
        }
    }
