    public static IsPropertyDefault(this DependencyObject obj, DependencyProperty dp)
    {
      return DependencyPropertyHelper.GetValueSource(obj, dp).BaseValueSource 
        == BaseValueSource.Default;
    }
    public static IsPropertySetLocally(this DependencyObject obj, DependencyProperty dp)
    {
      return DependencyPropertyHelper.GetValueSource(obj, dp).BaseValueSource 
        == BaseValueSource.Local;
    }
