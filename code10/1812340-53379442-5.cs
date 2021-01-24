    private System.Windows.Forms.Timer RotateTimer = null;
    private float RotationAngle1 = 90F;
    private float RotationAngle2 = 0F;
    public bool RotateFigures = false;
    public form1()
    {
        InitializeComponent();
        RotateTimer = new Timer();
        RotateTimer.Interval = 50;
        RotateTimer.Enabled = false;
        RotateTimer.Tick += new EventHandler(this.RotateTick);
    }
    protected void RotateTick(object sender, EventArgs e)
    {
        RotationAngle1 += 10F;
        RotationAngle2 += 10F;
        transparentPanel1.Invalidate();
        transparentPanel2.Invalidate();
    }
    private void btnRotate_Click(object sender, EventArgs e)
    {
        RotateTimer.Enabled = !RotateTimer.Enabled;
        if (RotateTimer.Enabled == false)
        {
            RotateFigures = false;
            RotationAngle1 = 90F;
            RotationAngle2 = 0F;
        }
        else
        {
            RotateFigures = true;
        }
    }
    private void transparentPanel1_Paint(object sender, PaintEventArgs e)
    {
        if (!RotateFigures) return;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        e.Graphics.CompositingMode = CompositingMode.SourceOver;
        Rectangle rect = transparentPanel1.ClientRectangle;
        Rectangle rectInner = rect;
        using (Pen transpPen = new Pen(transparentPanel1.Parent.BackColor, 10))
        using (Pen penOuter = new Pen(Color.SteelBlue, 8))
        using (Pen penInner = new Pen(Color.Teal, 8))
        using (Matrix m1 = new Matrix())
        using (Matrix m2 = new Matrix())
        {
            m1.RotateAt(-RotationAngle1, new PointF(rect.Width / 2, rect.Height / 2));
            m2.RotateAt(RotationAngle1, new PointF(rect.Width / 2, rect.Height / 2));
            rect.Inflate(-(int)penOuter.Width, -(int)penOuter.Width);
            rectInner.Inflate(-(int)penOuter.Width * 3, -(int)penOuter.Width * 3);
            e.Graphics.Transform = m1;
            e.Graphics.DrawArc(transpPen, rect, -4, 94);
            e.Graphics.DrawArc(penOuter, rect, -90, 90);
            e.Graphics.ResetTransform();
            e.Graphics.Transform = m2;
            e.Graphics.DrawArc(transpPen, rectInner, 190, 100);
            e.Graphics.DrawArc(penInner, rectInner, 180, 90);
        }
    }
    private void transparentPanel2_Paint(object sender, PaintEventArgs e)
    {
        if (!RotateFigures) return;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        e.Graphics.CompositingMode = CompositingMode.SourceOver;
        Rectangle rect = transparentPanel2.ClientRectangle;
        Rectangle rectInner = rect;
        using (Pen transpPen = new Pen(transparentPanel2.Parent.BackColor, 10))
        using (Pen penOuter = new Pen(Color.Orange, 8))
        using (Pen penInner = new Pen(Color.DarkRed, 8))
        using (Matrix m1 = new Matrix())
        using (Matrix m2 = new Matrix())
        {
            m1.RotateAt(RotationAngle2, new PointF(rect.Width / 2, rect.Height / 2));
            m2.RotateAt(-RotationAngle2, new PointF(rect.Width / 2, rect.Height / 2));
            rect.Inflate(-(int)penOuter.Width, -(int)penOuter.Width);
            rectInner.Inflate(-(int)penOuter.Width * 3, -(int)penOuter.Width * 3);
            e.Graphics.Transform = m1;
            e.Graphics.DrawArc(transpPen, rect, -4, 94);
            e.Graphics.DrawArc(penOuter, rect, 0, 90);
            e.Graphics.ResetTransform();
            e.Graphics.Transform = m2;
            e.Graphics.DrawArc(transpPen, rectInner, 190, 100);
            e.Graphics.DrawArc(penInner, rectInner, 180, 90);
        }
    }
