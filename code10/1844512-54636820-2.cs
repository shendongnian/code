    public class RichTextBoxEx : RichTextBox
    {
        protected override void OnCreateControl()
        {
            Text = "Hello World";
            base.OnCreateControl();
        }
    }
