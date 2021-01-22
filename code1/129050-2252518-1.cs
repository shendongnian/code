    public override Size MinimumSize
    {
        get
        {
            return base.MinimumSize;
        }
        set
        {
            // can see that Height is not taken in consideration - is 0
            base.MinimumSize = new Size(value.Width, 0); 
        }
    }
 
