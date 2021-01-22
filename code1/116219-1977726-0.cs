    public class NumericTextBox : TextBox
    {
    
        int value;
    
        public NumericTextBox()
            : base()
        {
            this.Text = "0";
            this.TextChanged += new TextChangedEventHandler(NumericTextBox_TextChanged);
        }
    
        void NumericTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int selectionStart = base.SelectionStart;
            bool changed = false;
            List<char> charList = new List<char>();
            for (int i = 0; i < base.Text.Length; i++)
            {
                if (IsValidChar(base.Text[i], i))
                {
                    charList.Add(base.Text[i]);
                }
                else
                {
                    if (selectionStart >= i)
                    {
                        selectionStart--;
                    }
                    changed = true;
                }
            }
            if (changed)
            {
                string text = new string(charList.ToArray());
                this.Text = text;
                this.SelectionStart = selectionStart;
            }
            int newValue;
            if (!int.TryParse(this.Text, out newValue))
            {
                this.Text = value.ToString();
                this.SelectionStart = this.Text.Length;
            }
            else
            {
                value = newValue;
            }
        }
    
        private bool IsValidChar(char c, int index)
        {
            return ((c == '-' && index == 0) || c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9');
        }
    
        private void HandleKeyEvent(KeyEventArgs e)
        {
            e.Handled = true;
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                e.Handled = false;
            }
            if (e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Left || e.Key == Key.Right ||
                e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6 ||
                e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9 ||
                e.Key == Key.NumPad0 || e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6 ||
                e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9)
            {
                e.Handled = false;
            }
            else if ((e.Key == Key.Subtract || (e.Key == Key.Unknown && e.PlatformKeyCode == 189)) && base.SelectionStart == 0 && (base.Text.Length == 0 || base.Text[0] != '-'))
            {
                e.Handled = false;
            }
        }
    
        protected override void OnKeyDown(KeyEventArgs e)
        {
            HandleKeyEvent(e);
            base.OnKeyDown(e);
        }
    
        protected override void OnKeyUp(KeyEventArgs e)
        {
            HandleKeyEvent(e);
            base.OnKeyUp(e);
        }
    }
