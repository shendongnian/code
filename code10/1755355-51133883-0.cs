    public class CustomLabel : Label
    {
        public event EventHandler ContentChanged;
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (ContentChanged != null)
                ContentChanged(this, EventArgs.Empty);
        }
    }
