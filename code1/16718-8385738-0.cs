      using System;
      using System.Windows;
      using System.Windows.Controls;
      using System.Windows.Input;
      using System.Windows.Interactivity;
 
      namespace DataArtist
      {
    public class NumericOnly : Behavior<TextBox>
    {
        private string Text { get; set; }
        private bool shiftKey;
        public bool StripOnExit { get; set; }
 
        public NumericOnly()
        {
            StripOnExit = false;
        }
 
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.KeyDown += KeyDown;
            AssociatedObject.KeyUp += KeyUp;
            AssociatedObject.GotFocus += GotFocus;
            AssociatedObject.LostFocus += LostFocus;
        }
 
        void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Shift)
            {
                shiftKey = false;
            }
        }
 
        void KeyDown(object sender, KeyEventArgs e)
        {
            if (StripOnExit != false || e.Key == Key.Tab || e.Key == Key.Enter)
            {
                return;
            }
 
            if (e.Key == Key.Shift)
            {
                shiftKey = true;
            }
            else
            {
                if (IsNumericKey(e.Key) == false)
                {
                    e.Handled = true;
                }
            }
        }
 
        void GotFocus(object sender, RoutedEventArgs e)
        {
            Text = AssociatedObject.Text;
        }
 
        private void LostFocus(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject.Text == Text)
            {
                return;
            }
 
            string content = string.Empty;
 
            foreach (var c in AssociatedObject.Text)
            {
                if (Char.IsNumber(c) == true)
                {
                    content += c;
                }
            }
 
            AssociatedObject.Text = content;
        }
 
        public bool IsNumericKey(Key key)
        {
            if (shiftKey == true)
            {
                return false;
            }
 
            string code = key.ToString().Replace("NumPad", "D");
 
            if (code[0] == 'D' && code.Length > 1)
            {
                return (Char.IsNumber(code[1]));
            }
 
            return false;
        }
 
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.KeyDown -= KeyDown;
            AssociatedObject.LostFocus -= LostFocus;
            AssociatedObject.GotFocus -= GotFocus;
        }
    }   
        }
           
