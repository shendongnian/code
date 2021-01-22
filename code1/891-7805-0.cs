    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            //do something specific here
            base.OnMouseDown(e);
        }
    }
