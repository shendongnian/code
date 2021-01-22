    public static bool IsOnPrimary(Window myWindow)
    {
        var rect = myWindow.RestoreBounds;
        Rectangle myWindowBounds= new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        return myWindowBounds.IntersectsWith(WinForms.Screen.PrimaryScreen.Bounds);
        /* Where
            using System.Drawing;
            using System.Windows;
            using WinForms = System.Windows.Forms;
         */
    }
