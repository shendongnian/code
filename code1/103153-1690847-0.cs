    public EventingConverter : IValueConverter
    {
      public event EventHandler Converted;
      public event EventHandler ConvertedBack;
      public object Convert(object value, ...)
      {
        if(Converted!=null) Converted(this, EventArgs.Empty);
        return value;
      }
      public object ConvertBack(object value, ...)
      {
        if(ConvertedBack!=null) ConvertedBack(this, EventArgs.Empty);
        return value;
      }
    }
