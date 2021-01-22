            using System.Windows.Forms;
            using System.Drawing;
            using System.Windows.Interop;
            Screen screen = Screen.FromHandle(new WindowInteropHelper(this).Handle);
            int i;
            for (i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (Screen.AllScreens[i] == screen) break;
            }
            i++; i = i % Screen.AllScreens.Length;
            this.WindowState = WindowState.Normal;
            int x = 0;
            for (int j = 0; j < i; j++)
            {
                x += Screen.AllScreens[j].Bounds.Width;
            }
            this.Left = x + 1;
            this.WindowState = WindowState.Maximized;
