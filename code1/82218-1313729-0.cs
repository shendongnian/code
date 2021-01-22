     public static class TextChangedBehavior
      {
        public static readonly DependencyProperty TextChangedCommandProperty =
            DependencyProperty.RegisterAttached("TextChangedCommand",
                                                typeof(ICommand),
                                                typeof(TextChangedBehavior),
                                                new PropertyMetadata(null, TextChangedCommandChanged));
    
        public static ICommand GetTextChangedCommand(DependencyObject obj)
        {
          return (ICommand)obj.GetValue(TextChangedCommandProperty);
        }
    
        public static void SetTextChangedCommand(DependencyObject obj, ICommand value)
        {
          obj.SetValue(TextChangedCommandProperty, value);
        }
    
        private static void TextChangedCommandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
          TextBoxBase textBox = obj as TextBoxBase;
    
          if (textBox != null)
          {
            textBox.TextChanged += new TextChangedEventHandler(HandleTextChanged);
          }
        }
    
        private static void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
          TextBox textBox = sender as TextBox;
          if (textBox != null)
          {
            ICommand command = GetTextChangedCommand(textBox);
            command.Execute(textBox.Text);
          }
        }
      }
