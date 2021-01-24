    const float borderWidth = 8.0f;
    Pen borderPen = new Pen(Color.Red, borderWidth) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset };
    
    public Form2()
    {
        InitializeComponent();
        this.Paint += Form2_Paint;
        this.Resize += Form2_Resize;
    }
    
    private void Form2_Resize(object sender, EventArgs e)
    {
        Invalidate();
    }
    
    private void Form2_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawRectangle(borderPen, this.ClientRectangle);
    }
