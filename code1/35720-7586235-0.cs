    // Get the correct binding expression based on type of binding
    //(simple binding or multi binding.
    BindingExpressionBase binding = 
      BindingOperations.GetBindingExpression(element, prop);
    if (binding == null)
    {
        binding = BindingOperations.GetMultiBindingExpression(element, prop);
    }
        
    if (binding != null)
    {
         object value = element.GetValue(prop);
         if (string.IsNullOrEmpty(value.ToString()) == true)
         {
             binding.UpdateTarget();
         }
         else
         {
              binding.UpdateSource();
         }
    }
