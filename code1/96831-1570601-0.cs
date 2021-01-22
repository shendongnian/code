       using System;
        using System.Windows.Forms;
        using System.Collections.Generic;
        using System.Text;
        using System.Runtime.InteropServices;
        
    namespace pl.emag.audiopc.gui {
        // ************************************************************************
    //`enter code here`
        // ************************************************************************
        public class PaintingHelper {
            // ********************************************************************
    //
            // ********************************************************************
            public static void SuspendDrawing(Control parent) {
                SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
            }
            // ********************************************************************
    //
            // ********************************************************************
            public static void ResumeDrawing(Control parent) {
                SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
                parent.Refresh();
            }
            // ********************************************************************
    //
            // ********************************************************************
            [DllImport("user32.dll")]
            private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, 
                bool wParam, Int32 lParam);
            // ********************************************************************
            //
            // ********************************************************************
            private const int WM_SETREDRAW = 11;
        }
    }
