      [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
    
     public Form1()
            {
                InitializeComponent();
                SendMessage(textBox1.Handle, EM_SETCUEBANNER, 1, "Username");
                SendMessage(textBox2.Handle, EM_SETCUEBANNER, 1, "Password");
    
            }
