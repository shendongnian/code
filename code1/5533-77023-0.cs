    public void EnableDoubleBuffering()
    {
       this.SetStyle(ControlStyles.DoubleBuffer | 
          ControlStyles.UserPaint | 
          ControlStyles.AllPaintingInWmPaint,
          true);
       this.UpdateStyles();
    }
