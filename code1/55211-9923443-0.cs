    public static class MyWatiNExtensions
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SetFocus(IntPtr hWnd);
    
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    
        public static void TypeTextQuickly(this TextField textField, string text)
        {
            textField.SetAttributeValue("value", text);
        }
    
        public static void PressEnter(this TextField textField)
        {
            SetForegroundWindow(textField.DomContainer.hWnd);
            SetFocus(textField.DomContainer.hWnd);
            textField.Focus();
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
        }
    }
