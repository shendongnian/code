    [DllImport("user32.dll")]
    public static extern int FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    public static extern int SetParent(int hWndChild, int hWndNewParent);
    [DllImport("user32.dll")]
    public static extern int MoveWindow(
        int hWnd, int x, int y, 
        int nWidth, int nHeight, int bRepaint);
    //
    private static int hwnExcel = 0;
    private System.Windows.Forms.PictureBox picContainer;
    // ...
    private void Principal_Resize(object sender, EventArgs e)
    {
        picContainer.Width = this.Width - 8;
        picContainer.Height = this.Height - 45;
        User32.SetParent(hwnExcel, 0);
        User32.MoveWindow(
            hwnExcel, 0, 0, 
            picContainer.Width, picContainer.Height, 1);
    }
