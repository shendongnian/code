        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetActiveWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(HandleRef hWnd, string text, string caption, int type);
    
 
         private static DialogResult GetResult(int val)
        {
            switch (val)
            {
                case 1:
                    return DialogResult.OK;
                case 2:
                    return DialogResult.Cancel;
                case 3:
                    return DialogResult.Abort;
                case 4:
                    return DialogResult.Retry;
                case 5:
                    return DialogResult.Ignore;
                case 6:
                    return DialogResult.Yes;
                case 7:
                    return DialogResult.No;
                default:
                    return DialogResult.No;
            }
        }
       IntPtr handle = GetActiveWindow();
            DialogResult dialogResult = GetResult(MessageBox(new HandleRef((object) this.Handle, handle), "Test", "test", 1));
