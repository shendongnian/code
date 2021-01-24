    using System.ComponentModel;
    using System.Drawing;
    using System.Security.Permissions;
    using System.Windows.Forms;
    [DesignerCategory("Code")]
    class ComboSimpleBorder : ComboBox
    {
        private const int WM_PAINT = 0xF;
        private Color m_BorderColor = Color.Red;
        public ComboSimpleBorder() { }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always), Category("Appearance")]
        [Description("Get or Set the Color of the Control's border")]
        public Color BorderColor 
        {
            get => this.m_BorderColor;
            set { this.m_BorderColor = value; this.Invalidate(); }
        }
        [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT) {
                using (Graphics g = Graphics.FromHwnd(this.Handle)) {
                    ControlPaint.DrawBorder(g, this.ClientRectangle, this.m_BorderColor, ButtonBorderStyle.Solid);
                }
                m.Result = IntPtr.Zero;
            }
        }
    }
