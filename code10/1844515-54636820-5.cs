    public class RichTextBoxEx : RichTextBox
    {
        private bool _initialized = false;
        protected override void OnCreateControl()
        {
            if (!_initialized)
            {
                _initialized = true;
                Text = "Hello World";
            }
            base.OnCreateControl();
        }
    }
