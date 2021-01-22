    public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
                this.simpleLine1.BringToFront();
            }
        }
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    public class SimpleLine : Control
    {
        public enum LineType
        {
            Horizontal,
            Vertical,
            ForwardsDiagonal,
            BackwardsDiagonal
        }
        public event EventHandler AppearanceChanged;
        private LineType appearance;
        public virtual LineType Appearance
        {
            get
            {
                return appearance;
            }
            set
            {
                if (appearance != value)
                {
                    this.SuspendLayout();
                    switch (appearance)
                    {
                        case LineType.Horizontal:
                            if (value == LineType.Vertical)
                            {
                                this.Height = this.Width;
                            }
                            
                            break;
                        case LineType.Vertical:
                            if (value == LineType.Horizontal)
                            {
                                this.Width = this.Height;
                            }
                            break;
                    }
                    this.ResumeLayout(false);
                    appearance = value;
                    this.PerformLayout();
                    this.Invalidate();
                }
            }
        }
        protected virtual void OnAppearanceChanged(EventArgs e)
        {
            if (AppearanceChanged != null) AppearanceChanged(this, e);
        }
        public event EventHandler LineColorChanged;
        private Color lineColor;
        public virtual Color LineColor
        {
            get
            {
                return lineColor;
            }
            set
            {
                if (lineColor != value)
                {
                    lineColor = value;
                    this.Invalidate();
                }
            }
        }
        protected virtual void OnLineColorChanged(EventArgs e)
        {
            if (LineColorChanged != null) LineColorChanged(this, e);
        }
        public event EventHandler LineWidthChanged;
        private float lineWidth;
        public virtual float LineWidth
        {
            get
            {
                return lineWidth;
            }
            set
            {
                if (lineWidth != value)
                {
                    if (0 >= value)
                    {
                        lineWidth = 1;
                    }
                    lineWidth = value;
                    this.PerformLayout();
                }
            }
        }
        protected virtual void OnLineWidthChanged(EventArgs e)
        {
            if (LineWidthChanged != null) LineWidthChanged(this, e);
        }
        public SimpleLine()
        {
            base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Selectable, false);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.BackColor = Color.Transparent;
            InitializeComponent();
       
            appearance = LineType.Vertical;
            LineColor = Color.Black;
            LineWidth = 1;
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
                return cp;
            }
        }
        private System.ComponentModel.IContainer components = null;
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
      
        protected override void OnLayout(LayoutEventArgs levent)
        {
            switch (this.Appearance)
            {
                case LineType.Horizontal:
                    this.Height = (int)LineWidth;
                    this.Invalidate();
                    break;
                case LineType.Vertical:
                    this.Width = (int)LineWidth;
                    this.Invalidate();
                    break;
            }
            base.OnLayout(levent);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            //base.OnPaint(pe);
            switch (Appearance)
            {
                case LineType.Horizontal:
                    DrawHorizontalLine(pe);
                    break;
                case LineType.Vertical:
                    DrawVerticalLine(pe);
                    break;
                case LineType.ForwardsDiagonal:
                    DrawFDiagonalLine(pe);
                    break;
                case LineType.BackwardsDiagonal:
                    DrawBDiagonalLine(pe);
                    break;
            }
        }
        private void DrawFDiagonalLine(PaintEventArgs pe)
        {
            int x, y, x1, y1;
            x = this.ClientRectangle.X;
            y = this.ClientRectangle.Bottom;
            x1 = this.ClientRectangle.Right;
            y1 = this.ClientRectangle.Y;
            using (Pen p = new Pen(this.LineColor, this.LineWidth))
            {
                pe.Graphics.DrawLine(p, x, y, x1, y1);
            }
        }
        private void DrawBDiagonalLine(PaintEventArgs pe)
        {
            int x, y, x1, y1;
            x = this.ClientRectangle.X;
            y = this.ClientRectangle.Y;
            x1 = this.ClientRectangle.Right;
            y1 = this.ClientRectangle.Bottom;
            using (Pen p = new Pen(this.LineColor, this.LineWidth))
            {
                pe.Graphics.DrawLine(p, x, y, x1, y1);
            }
        }
        private void DrawHorizontalLine(PaintEventArgs pe)
        {
            int x, y, x1;
            x = this.ClientRectangle.X;
            y = this.ClientRectangle.Height / 2;
            x1 = this.ClientRectangle.Width;
            using (Pen p = new Pen(this.LineColor, this.LineWidth))
            {
                pe.Graphics.DrawLine(p, x, y, x1, y);
            }
        }
        private void DrawVerticalLine(PaintEventArgs pe)
        {
            int x, y, y1;
            x = this.ClientRectangle.Width / 2;
            y = this.ClientRectangle.Y;
            y1 = this.ClientRectangle.Height;
            using (Pen p = new Pen(this.LineColor, this.LineWidth))
            {
                pe.Graphics.DrawLine(p, x, y, x, y1);
            }
        }
    }
