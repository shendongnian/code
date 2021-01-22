    public class ConditionalSetter : DependencyObject
    {
      public string GetProperty( ... // Attached property
      public void SetProperty( ...
      public static readonly DependencyProperty PropertyProperty = ...
      {
        PropertyChangedCallback = Update,
      });
      public object GetValue( ... // Attached property
      public void SetValue( ...
      public static readonly DependencyProperty ValueProperty = ...
      {
        PropertyChangedCallback = Update,
      });
      void Update(DependencyObject obj, DependencyPropertyChangedEventArgs e)
      {
        var property = GetProperty(obj);
        var value = GetValue(obj);
        if(property==null) return;
  
        var prop = DependencyPropertyDescriptor.FromName(property, obj.GetType(), typeof(object)).DependencyProperty;
        if(prop==null) return;
       
        if(value!=null)
          obj.SetValue(prop, value);
        else
          obj.ClearValue(prop);
      }
    }
