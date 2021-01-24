    public class MyTextBox : TextBox
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            BackColor = Color.Red;
        }
    }
