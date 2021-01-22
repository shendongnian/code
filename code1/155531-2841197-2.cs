    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication1
    {
      public partial class CustomBorderForm : Form
      {
        const int WM_NCPAINT = 0x85;
    
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);
    
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
    
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void DisableProcessWindowsGhosting();
    
        [DllImport("UxTheme.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);
    
        public CustomBorderForm()
        {
          // This could be called from main.
          DisableProcessWindowsGhosting();
    
          InitializeComponent();
        }
    
        protected override void OnHandleCreated(EventArgs e)
        {
          SetWindowTheme(this.Handle, "", "");
          base.OnHandleCreated(e);
        }
    
        protected override void WndProc(ref Message m)
        {
          base.WndProc(ref m);
          
          switch (m.Msg)
          {
            case WM_NCPAINT:
              {
                IntPtr hdc = GetWindowDC(m.HWnd);
                using (Graphics g = Graphics.FromHdc(hdc))
                {
                  g.FillEllipse(Brushes.Red, new Rectangle((Width-20)/2, 8, 20, 20));
                }
                int r = ReleaseDC(m.HWnd, hdc);
              }
              break;
          }
        }
      }
    }
