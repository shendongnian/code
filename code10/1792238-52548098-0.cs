                TextBox txtBox = new TextBox();
                txtBox.DataContext = // Your data;
                
                Binding binding = new Binding();
                binding.Path = // Set path;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                binding.ValidatesOnDataErrors = true;
                binding.NotifyOnValidationError = true;
                binding.ValidationRules.Add(// Your ValidationRule class);
                txtBox.SetBinding(TextBox.TextProperty, binding);
