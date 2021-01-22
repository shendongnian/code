        public bool CanExecuteUpdateTextBoxBindingOnEnterCommand(object parameter)
        {
            return true;
        }
        public void ExecuteUpdateTextBoxBindingOnEnterCommand(object parameter)
        {
            TextBox tBox = parameter as TextBox;
            if (tBox != null)
            {
                DependencyProperty prop = TextBox.TextProperty;
                BindingExpression binding = BindingOperations.GetBindingExpression(tBox, prop);
                if (binding != null) 
                    binding.UpdateSource();
            }
        }
