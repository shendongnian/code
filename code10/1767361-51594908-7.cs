    public class MyCustomTextBox : TextBox
    {
        static MyCustomTextBox()
        {
            TextProperty.OverrideMetadata(typeof(MyCustomTextBox), new FrameworkPropertyMetadata(OnTextChanged));
        }
    
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (MyCustomTextBox)d;
            var str = (string)e.NewValue;
            SolidColorBrush foreGround;
            if (str == null)
            {
                foreGround = new SolidColorBrush(Colors.Black);
            }
            else
            {
                foreGround = str.StartsWith("<qs>") && str.EndsWith("<qe>") ? new SolidColorBrush(Colors.Red) :
                    str.StartsWith("<as>") && str.EndsWith("<ae>") ? new SolidColorBrush(Colors.Green) :
                    new SolidColorBrush(Colors.Black);
            }
    
            control.Foreground = foreGround;
        }
    }
