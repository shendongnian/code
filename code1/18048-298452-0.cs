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
            Vertical
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
                    appearance = value;
                    switch (value)
                    {
                        case LineType.Horizontal:
                            this.Width = this.Height;
                            break;
                        case LineType.Vertical:
                            this.Height = this.Width;
                            break;
                    }
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
            InitializeComponent();
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.UserPaint | 
                ControlStyles.ResizeRedraw | 
                ControlStyles.SupportsTransparentBackColor ,true);
            this.SetStyle(ControlStyles.Opaque, false);
            base.BackColor = Color.Transparent;
            Appearance = LineType.Vertical;
            LineColor = Color.Black;
            LineWidth = 1;
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
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            switch (Appearance)
            {
                case LineType.Horizontal:
                    DrawHorizontalLine(pe);
                    break;
                case LineType.Vertical:
                    DrawVerticalLine(pe);
                    break;
            }
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
