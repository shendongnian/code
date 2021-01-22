    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication1 {
      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
        }
        protected override void WndProc(ref Message m) {
          if (m.Msg == 0x216) { // Trap WM_MOVING
            RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
            Screen scr = Screen.FromRectangle(Rectangle.FromLTRB(rc.left, rc.top, rc.right, rc.bottom));
            if (rc.left < scr.WorkingArea.Left) {rc.left = scr.WorkingArea.Left; rc.right = rc.left + this.Width; }
            if (rc.top < scr.WorkingArea.Top) { rc.top = scr.WorkingArea.Top; rc.bottom = rc.top + this.Height; }
            if (rc.right > scr.WorkingArea.Right) { rc.right = scr.WorkingArea.Right; rc.left = rc.right - this.Width; }
            if (rc.bottom > scr.WorkingArea.Bottom) { rc.bottom = scr.WorkingArea.Bottom; rc.top = rc.bottom - this.Height; }
            Marshal.StructureToPtr(rc, m.LParam, false);
          }
          base.WndProc(ref m);
        }
        private struct RECT {
          public int left; 
          public int top; 
          public int right; 
          public int bottom; 
        }
      }
    }
