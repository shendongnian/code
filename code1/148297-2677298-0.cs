    public static readonly DependencyProperty Date =
      DependencyProperty.Register("ReturnDate", typeof(DateTime), typeof(DatePicker),
      new FrameworkPropertyMetadata(
            DateTime.Now, 
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            new PropertyChangedCallback(dateChanged)));
    public DateTime ReturnDate
     {
        get { return Convert.ToDateTime(GetValue(Date)); }
        set
        {
            SetDropDowns(value);
            SetValue(Date, value);
        }
     }
    private static void OnCurrentReadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      DatePicker instance = d as DatePicker;
      d.SetDropDowns((DateTime)e.NewValue);
    }
