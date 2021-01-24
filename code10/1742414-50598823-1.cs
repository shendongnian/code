      binding.Mode = BindingMode.OneWay;
      binding.IsAsync = false;
      binding.UpdateSourceTrigger = UpdateSourceTrigger.Default;
      binding.TargetNullValue = "null";
      BindingOperations.SetBinding(tb, TextBox.TextProperty, binding);
     }
