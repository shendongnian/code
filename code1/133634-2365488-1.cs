    private void Window_Loaded(object sender, RoutedEventArgs e) {
        SetParentIcon();
    }
    private void SetParentIcon() {
        WindowInteropHelper ih = new WindowInteropHelper(this);
        if(this.Owner == null && ih.Owner != IntPtr.Zero) { //We've found the invisible window
            System.Drawing.Icon icon = new System.Drawing.Icon("ApplicationIcon.ico");
            SendMessage(ih.Owner, 0x80 /*WM_SETICON*/, (IntPtr)1 /*ICON_LARGE*/, icon.Handle); //Change invisible window's icon
        }
    }
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
