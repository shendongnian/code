    String BindingName = inName.Substring(3);
    
    BindingBase BB = BindingOperations.GetBindingBase(
                     (DependencyObject)this.FindName(BindingName),
                     TextBox.TextProperty);
    
    var oldBind = BB as Binding;
      
    if (BB != null)
    {
      //the magic goes here
      Binding binding = new Binding("Text");
      binding.Source = (DependencyObject)this.FindName(BindingName);
      
      binding.Mode = BindingMode.OneWay;
      binding.IsAsync = false;
      binding.UpdateSourceTrigger = UpdateSourceTrigger.Default;
      binding.TargetNullValue = "null";
      BindingOperations.SetBinding(tb, TextBox.TextProperty, binding);
     }
