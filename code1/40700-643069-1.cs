         Binding binding = BindingOperations.GetBinding(this, TextProperty);
         if (binding.UpdateSourceTrigger == UpdateSourceTrigger.Default ||
             binding.UpdateSourceTrigger == UpdateSourceTrigger.LostFocus)
         {
            BindingOperations.GetBindingExpression(this, TextProperty).UpdateSource();
         }
