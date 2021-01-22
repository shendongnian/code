    public static readonly DependencyProperty ThemeProperty = DependencyProperty.Register("Theme", typeof(MyTheme), typeof(Subpage), new PropertyMetadata
    {
      PropertyChangedCallback = (obj, e) =>
      {
        ((Subpage)obj).SetTheme((Theme)e.NewValue);
      }
    });
