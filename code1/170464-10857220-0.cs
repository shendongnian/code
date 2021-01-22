    using System.Windows.Forms;
    using System.Drawing;
    public static void MaximizeBrowser(this IE myBrowser)
    {
        myBrowser.SizeWindow(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
    }
