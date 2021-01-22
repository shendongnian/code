    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    
    namespace MyNamespace
    {
      public class MouseWheelManagedForm : Form, IMessageFilter
      {
        private bool managed;
    
        public MouseWheelManagedForm () : this (true) {
       }
    
        public MouseWheelManagedForm (bool start) {
          managed = false;
          if (start)
            ManagedMouseWheelStart();
        }
    
        protected override void Dispose (bool disposing) {
          if (disposing)
            ManagedMouseWheelStop();
          base.Dispose(disposing);
        }
    
        /************************************
         * IMessageFilter implementation
         * *********************************/
        private const int WM_MOUSEWHEEL = 0x20a;
        // P/Invoke declarations
        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint (Point pt);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage (IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    
        private bool IsChild (Control ctrl) {
          Control loopCtrl = ctrl;
    
          while (loopCtrl != null && loopCtrl != this)
            loopCtrl = loopCtrl.Parent;
    
          return (loopCtrl == this);
        }
    
        public bool PreFilterMessage (ref Message m) {
          if (m.Msg == WM_MOUSEWHEEL) {
            //Ensure the message was sent to a child of the current form
            if (IsChild(Control.FromHandle(m.HWnd))) {
              // Find the control at screen position m.LParam
              Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
    
              //Ensure control under the mouse is valid and is not the target control
              //otherwise we'd be trap in a loop.
              IntPtr hWnd = WindowFromPoint(pos);
              if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null) {
                SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                return true;
              }
            }
          }
          return false;
        }
    
        /****************************************
         * MouseWheelManagedForm specific methods
         * **************************************/
        public void ManagedMouseWheelStart () {
          if (!managed) {
            managed = true;
            Application.AddMessageFilter(this);
          }
        }
    
        public void ManagedMouseWheelStop () {
          if (managed) {
            managed = false;
            Application.RemoveMessageFilter(this);
          }
        }
    
      }
    }
