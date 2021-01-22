    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    public class wbExt : System.Windows.Forms.WebBrowser
    {
        private BorderStyle _borderStyle;
        [
        Category("Appearance"),
        Description("The border style")
        ]
        public BorderStyle BorderStyle
        {
            get
            {
                return _borderStyle;
            }
            set
            {
                _borderStyle = value;
                this.RecreateHandle();
                Invalidate();
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_BORDER = 0x00800000;
                const int WS_EX_STATICEDGE = 0x00020000;
                CreateParams cp = base.CreateParams;
                switch (_borderStyle)
                {
                    case BorderStyle.FixedSingle:
                        cp.Style |= WS_BORDER;
                        break;
                    case BorderStyle.Fixed3D:
                        cp.ExStyle |= WS_EX_STATICEDGE;
                        break;
                }
                return cp;
            }
        }
        public wbExt()
        {
        }
    }
