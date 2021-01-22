    public class AdvanceOnEnterTextBox : UserControl
    {
        TextBox _TextBox;
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(String), typeof(AdvanceOnEnterTextBox), null);
        public static readonly DependencyProperty InputScopeProperty = DependencyProperty.Register("InputScope", typeof(InputScope), typeof(AdvanceOnEnterTextBox), null);
        public AdvanceOnEnterTextBox()
        {
            _TextBox = new TextBox();
            _TextBox.KeyDown += customKeyDown;
            Content = _TextBox;
            
        }
        /// <summary>
        /// Text for the TextBox
        /// </summary>
        public String Text
        {
            get { return _TextBox.Text; }
            set { _TextBox.Text = value; }
        }
        /// <summary>
        /// Inputscope for the Custom Textbox
        /// </summary>
        public InputScope InputScope
        {
            get { return _TextBox.InputScope; }
            set { _TextBox.InputScope = value; }
        }
        void customKeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Key.Equals(Key.Enter)) return;
            var element = ((TextBox)sender).Parent as AdvanceOnEnterTextBox;
            if (element != null)
            {
                int currentElementPosition = ((Grid)element.Parent).Children.IndexOf(element);
                try
                {
                    // Jump to the next AdvanceOnEnterTextBox (assuming, that Labels are inbetween).
                    ((AdvanceOnEnterTextBox)((Grid)element.Parent).Children.ElementAt(currentElementPosition + 2)).Focus();
                }
                catch (Exception)
                {
                    // Close Keypad if this was the last AdvanceOnEnterTextBox
                    ((AdvanceOnEnterTextBox)((Grid)element.Parent).Children.ElementAt(currentElementPosition)).IsEnabled = false;
                    ((AdvanceOnEnterTextBox)((Grid)element.Parent).Children.ElementAt(currentElementPosition)).IsEnabled = true;
                }
            }
        }
    }
