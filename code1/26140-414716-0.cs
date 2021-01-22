    public class StringBuilderWrapper
    {
       private StringBuilder _builder = new StringBuilder();
       private EventHandler<EventArgs> TextChanged;
       public void Add(string text)
       {
         _builder.Append(text);
         if (TextChanged != null)
           TextChanged(this, null);
       }
       public string Text
       {
         get { return _builder.ToString(); }
       }
    }
