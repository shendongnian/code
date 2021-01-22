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
    using System.Collections.Generic;
    public class SimpleLine : Control
    {
        private Control parentHooked;   
        private List<Control> controlsHooked;
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
            controlsHooked = new List<Control>();
           
            this.ParentChanged += new EventHandler(OnSimpleLineParentChanged);
        }
        private void RemoveControl(Control control)
        {
            if (controlsHooked.Contains(control))
            {
                control.Paint -= new PaintEventHandler(OnControlPaint);
                if (control is TextboxX)
                {
                    TextboxX text = (TextboxX)control;
                    text.DoingAPaint -= new EventHandler(text_DoingAPaint);
                }
                controlsHooked.Remove(control);
            }
        }
        void text_DoingAPaint(object sender, EventArgs e)
        {
            this.Invalidate();
        }
   
        private void AddControl(Control control)
        {
            if (!controlsHooked.Contains(control))
            {
                control.Paint += new PaintEventHandler(OnControlPaint);
                if (control is TextboxX)
                {
                    TextboxX text = (TextboxX)control;
                    text.DoingAPaint += new EventHandler(text_DoingAPaint);
                }
                controlsHooked.Add(control);
            }
        }
      
        private void OnSimpleLineParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                foreach (Control c in Parent.Controls)
                {
                    AddControl(c);
                }
                Parent.ControlAdded += new ControlEventHandler(OnParentControlAdded);
                Parent.ControlRemoved += new ControlEventHandler(OnParentControlRemoved);
                parentHooked = this.Parent;
            }
            else
            {
                if (parentHooked != null)
                {
                    foreach (Control c in parentHooked.Controls)
                    {
                        RemoveControl(c);
                    }
                    parentHooked.ControlAdded -= new ControlEventHandler(OnParentControlAdded);
                    parentHooked.ControlRemoved -= new ControlEventHandler(OnParentControlRemoved);
                    parentHooked = null;
                }
            }
        }
      
        private void OnParentControlRemoved(object sender, ControlEventArgs e)
        {
            RemoveControl(e.Control);
        }   
      
        private void OnControlPaint(object sender, PaintEventArgs e)
        {
            int indexa =Parent.Controls.IndexOf(this) , indexb = Parent.Controls.IndexOf((Control)sender);
            //if above invalidate on paint
            if(indexa < indexb)
            {
                Invalidate();
            }
        }
        private void OnParentControlAdded(object sender, ControlEventArgs e)
        {
            AddControl(e.Control);
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
                return cp;
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
       
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //disable background paint
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
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
            using (Pen p = new Pen(this.LineColor, this.LineWidth))
            {
                pe.Graphics.DrawLine(p, this.ClientRectangle.X, this.ClientRectangle.Bottom,
                                        this.ClientRectangle.Right, this.ClientRectangle.Y);
            }
        }
        private void DrawBDiagonalLine(PaintEventArgs pe)
        {
            using (Pen p = new Pen(this.LineColor, this.LineWidth))
            {
                pe.Graphics.DrawLine(p, this.ClientRectangle.X, this.ClientRectangle.Y,
                                        this.ClientRectangle.Right, this.ClientRectangle.Bottom);
            }
        }
        private void DrawHorizontalLine(PaintEventArgs pe)
        {
            int  y = this.ClientRectangle.Height / 2;
            using (Pen p = new Pen(this.LineColor, this.LineWidth))
            {
                pe.Graphics.DrawLine(p, this.ClientRectangle.X, y,
                                        this.ClientRectangle.Width, y);
            }
        }
        private void DrawVerticalLine(PaintEventArgs pe)
        {
            int x = this.ClientRectangle.Width / 2;
            using (Pen p = new Pen(this.LineColor, this.LineWidth))
            {
                pe.Graphics.DrawLine(p,x, this.ClientRectangle.Y,
                                       x, this.ClientRectangle.Height);
            }
        }
    }
