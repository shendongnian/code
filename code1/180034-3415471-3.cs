    private System.Drawing.Drawing2D.HatchBrush GetHatchBrush()
    {
        System.Drawing.Color c = System.Drawing.Color.Red;
        System.Drawing.Drawing2D.HatchBrush h = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal, c);
        return h;
    }
