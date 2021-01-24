    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
----
    public class FormWithDesignSize : Form
    {
        private const Int32 DefaultMax = 2000; //set this to whatever you need
    
        private Int32 _MaxDesignWidth = DefaultMax;
        private Int32 _MaxDesignHeight = DefaultMax;
    
        [Category("Design"), DisplayName("MaxDesignWidth")]
        public Int32 aaa_MaxDesignWidth //Prefix aaa_ is to force Designer code placement before ClientSize setting
        {
            get // avoids need to write customer serializer code
            {
                return _MaxDesignWidth;
            }
            set
            {
                _MaxDesignWidth = value;
            }
        }
    
        [Category("Design"), DisplayName("MaxDesignHeight")]
        public Int32 aaa_MaxDesignHeight //Prefix aaa_ is to force Designer code placement before ClientSize setting
        {
            get // avoids need to write customer serializer code
            {
                return _MaxDesignHeight;
            }
            set
            {
                _MaxDesignHeight = value;
            }
        }
    
    
        protected override void SetBoundsCore(Int32 x, Int32 y, Int32 width, Int32 height, BoundsSpecified specified)
        {
            if (this.DesignMode)
            {
                // The Forms.Form.SetBoundsCore method limits the size based on SystemInformation.MaxWindowTrackSize
    
                // From the GetSystemMetrics function documentation for SMCXMINTRACK: 
                //   "The minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size 
                //    smaller than these dimensions. A window can override this value by processing the WMGETMINMAXINFO
                //    message."
                // See: http://msdn.microsoft.com/en-us/library/windows/desktop/ms724385%28v=vs.85%29.aspx
    
                // This message also appears to control the size set by the MoveWindow API, 
                // so it is intercepted and the maximum size is set to MaxWidth by MaxHeight
                // in the WndProc method when in DesignMode.
    
                // Form.SetBoundsCore ultimately calls Forms.Control.SetBoundsCore that calls SetWindowPos but, 
                // MoveWindow will be used instead to set the Window size when in the designer as it requires less
                // parameters to achieve the desired effect.
    
                MoveWindow(this.Handle, this.Left, this.Top, width, height, true);
            }
            else
            {
                base.SetBoundsCore(x, y, width, height, specified);
            }
        }
    
        private const Int32 WMGETMINMAXINFO = 0x24;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (this.DesignMode && m.Msg == WMGETMINMAXINFO)
            {
    
                MINMAXINFO MMI = new MINMAXINFO();
                // retrieve default MINMAXINFO values from the structure pointed to by m.LParam
                Marshal.PtrToStructure(m.LParam, MMI);
    
                // reset the ptMaxTrackSize value
                MMI.ptMaxTrackSize = new POINTAPI(_MaxDesignWidth, _MaxDesignHeight);
    
                // copy the modified structure back to LParam
                Marshal.StructureToPtr(MMI, m.LParam, true);
            }
    
        }
    
        [StructLayout(LayoutKind.Sequential)]
        private class MINMAXINFO
        {
            public POINTAPI ptReserved;
            public POINTAPI ptMaxSize;
            public POINTAPI ptMaxPosition;
            public POINTAPI ptMinTrackSize;
            public POINTAPI ptMaxTrackSize;
        }
    
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct POINTAPI
        {
            public Int32 X;
            public Int32 Y;
    
            public POINTAPI(Int32 X, Int32 Y) : this()
            {
                this.X = X;
                this.Y = Y;
            }
    
            public override string ToString()
            {
                return "(" + X.ToString() + ", " + Y.ToString() + ")";
            }
        }
    
        [DllImport("user32.dll")]
        private extern static bool MoveWindow(IntPtr hWnd, Int32 x, Int32 y, Int32 nWidth, Int32 nHeight, bool bRepaint);
    
    }
