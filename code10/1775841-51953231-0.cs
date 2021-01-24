    using System;
    using System.Windows.Forms;
    
    namespace JeremyHelp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                this.SetDraggable(this.bunifuGradientPanel1, vertical: false);
            }
    
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams handleParam = base.CreateParams;
                    handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                    return handleParam;
                }
            }
    
            private void SetDraggable(Control target, bool horizontal = true, bool vertical = true)
            {
                bool IsDraggable = false;
                int
                X = 0, Y = 0,
                A = 0, B = 0;
    
                target.MouseUp += (s, e) =>
                {
                    IsDraggable = false;
                    X = 0; Y = 0;
                    A = 0; B = 0;
                };
    
                target.MouseDown += (s, e) =>
                {
                    IsDraggable = true;
                    A = Control.MousePosition.X - target.Left;
                    B = Control.MousePosition.Y - target.Top;
                };
    
                target.MouseMove += (s, e) =>
                {
                    X = Control.MousePosition.X;
                    Y = Control.MousePosition.Y;
    
                    if (IsDraggable)
                    {
                        if (horizontal) target.Left = X - A;
                        if (vertical) target.Top = Y - B;
                    }
                };
            }
        }
    }
