     public static DependencyProperty TestProperty = DependencyProperty.Register("Test",  
       typeof(ItemEnum), typeof(TestActivity), new PropertyMetadata(ItemEnum.First));
    [Description("Select Item value")]
    [Category("Settings")]
    [DefaultValue(ItemEnum.First)]
    public ItemEnum Type
    {
      get
      {
        return (ItemEnum)GetValue(TestActivity.TestProperty);
      }
      set
      {
        SetValue(TestActivity.TestProperty, value);
      }
    }
