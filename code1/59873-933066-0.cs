    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace VerticalMovingForm
    {
        public partial class Form1 : Form
        {
            private const int WM_MOVING = 0x0216;
            private readonly int positionX;
            private readonly int positionR;
    
            public Form1()
            {
                Left = 400;
                Width = 500;                            
                positionX = Left;
                positionR = Left + Width;
            }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_MOVING)
                {
                    var r = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                    r.Left = positionX;
                    r.Right = positionR;
                    Marshal.StructureToPtr(r, m.LParam, false);
                }
                base.WndProc(ref m);                
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
        }
    }
