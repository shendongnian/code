    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace Question_Answer_WPF_App.Attachable
    {
        public class Commands
        {
            public static ICommand GetTextChangedCommand(TextBox textBox) 
                => (ICommand)textBox.GetValue(TextChangedCommandProperty);
            public static void SetTextChangedCommand(TextBox textBox, ICommand command) 
                => textBox.SetValue(TextChangedCommandProperty, command);
            public static readonly DependencyProperty TextChangedCommandProperty =
                DependencyProperty.RegisterAttached(
                    "TextChangedCommand", 
                    typeof(ICommand), 
                    typeof(Commands),
                    new PropertyMetadata(null, new PropertyChangedCallback((s, e) =>
                    {
                        if (s is TextBox textBox && e.NewValue is ICommand command)
                        {
                            textBox.TextChanged -= textBoxTextChanged;
                            textBox.TextChanged += textBoxTextChanged;    
                            void textBoxTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
                            {
                                var commandParameter = GetTextChangedCommandParameter(textBox);
                                if (command.CanExecute(commandParameter))
                                    command.Execute(commandParameter);
                            }
                        }
                    })));
    
            public static object GetTextChangedCommandParameter(TextBox textBox) 
                => textBox.GetValue(TextChangedCommandParameterProperty);
            public static void SetTextChangedCommandParameter(TextBox textBox, object commandParameter) 
                => textBox.SetValue(TextChangedCommandParameterProperty, commandParameter);
            public static readonly DependencyProperty TextChangedCommandParameterProperty =
                DependencyProperty.RegisterAttached("TextChangedCommandParameter", typeof(object), typeof(Commands), new PropertyMetadata(null));
        }
    }
