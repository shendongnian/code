    public class MyTextBox: TextBox
    {
    ...
            private new ContentAlignment TextAlign
            {
              get { return base.ContentAlignment; }
              set { base.ContentAlignment = value; }
            }
    }
