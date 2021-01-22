    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace MyNamespace
    {
        public partial class RotatedText : UserControl
        {
            private readonly Timer _invalidationTimer;
            private const int WS_EX_TRANSPARENT = 0x00000020;
    
            public RotatedText()
            {
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                InitializeComponent();
    
                _invalidationTimer = new Timer {Interval = 500, Enabled = true};
                _invalidationTimer.Tick += TickHandler;
            }
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [Category("Appearance")]
            [Description("Text which appears in control")]
            public string Text { get; set; }
    
            #region Transparent background
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= WS_EX_TRANSPARENT;
                    return cp;
                }
            }
    
            private void TickHandler(object sender, EventArgs e)
            {
                InvalidateEx();
            }
    
            private void InvalidateEx()
            {
                if (Parent != null)
                    Parent.Invalidate(Bounds, false);
                else
                    Invalidate();
            }
    
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                //Intentionally do nothing - stops background from drawing
                //base.OnPaintBackground(e);
            } 
            #endregion
    
            //Rotate text and draw
            protected override void OnPaint(PaintEventArgs e)
            {
                double angleRadians = Math.Atan2(Height, Width);
                float angleDegrees = -1*(float) (angleRadians*180/Math.PI);
                angleDegrees *= 0.9f;
                e.Graphics.RotateTransform(angleDegrees, MatrixOrder.Append);
                e.Graphics.TranslateTransform(20, Height - 75, MatrixOrder.Append);
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                Font font = new Font("Ariel", 50);
                e.Graphics.DrawString(Text, font, Brushes.Gray, 1, 2); //Shadow
                e.Graphics.DrawString(Text, font, Brushes.Red, 0, 0);
            }
        }
    }
