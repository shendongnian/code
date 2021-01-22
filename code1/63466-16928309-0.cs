    //using System.Windows.Forms;
    
    public bool IsOnScreen(Window window)
    {
       var windowRect = new System.Drawing.Rectangle((int)window.Left, (int)window.Top, (int)window.Width, (int)window.Height);
       return Screen.AllScreens.Any(s => s.WorkingArea.IntersectsWith(windowRect));
    }
