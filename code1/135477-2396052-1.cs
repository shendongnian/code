    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public class MyComboBox : ComboBox {
      protected override void OnDropDown(EventArgs e) {
        // Is dropdown off the right side of the screen?
        Point pos = this.PointToScreen(this.Location);
        Screen scr = Screen.FromPoint(pos);
        if (scr.WorkingArea.Right < pos.X + this.DropDownWidth) {
           this.BeginInvoke(new Action(() => {
            // Retrieve handle to dropdown list
            COMBOBOXINFO info = new COMBOBOXINFO();
            info.cbSize = Marshal.SizeOf(info);
            SendMessageCb(this.Handle, 0x164, IntPtr.Zero, out info);
            // Move the dropdown window
            RECT rc;
            GetWindowRect(info.hwndList, out rc);
            int x = scr.WorkingArea.Right - (rc.Right - rc.Left);
            SetWindowPos(info.hwndList, IntPtr.Zero, x, rc.Top, 0, 0, 5);
          }));
        }
        base.OnDropDown(e);
      }
    
      // P/Invoke declarations
      private struct COMBOBOXINFO {
        public Int32 cbSize;
        public RECT rcItem, rcButton;
        public int buttonState;
        public IntPtr hwndCombo, hwndEdit, hwndList;
      }
      private struct RECT {
        public int Left, Top, Right, Bottom;
      }
      [DllImport("user32.dll", EntryPoint = "SendMessageW", CharSet = CharSet.Unicode)]
      private static extern IntPtr SendMessageCb(IntPtr hWnd, int msg, IntPtr wp, out COMBOBOXINFO lp);
      [DllImport("user32.dll")]
      private static extern bool SetWindowPos(IntPtr hWnd, IntPtr after, int x, int y, int cx, int cy, int flags);
      [DllImport("user32.dll")]
      private static extern bool GetWindowRect(IntPtr hWnd, out RECT rc);
    }
