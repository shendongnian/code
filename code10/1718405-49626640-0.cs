    protected override bool Move(ref Message msg, Keys KeyData)
    {
        if (KeyData.HasFlag(Keys.Up))
        {
            bluePoint.Y -= normalSpeed;
        }
        if (KeyData.HasFlag(Keys.Down))
        {
            bluePoint.Y += normalSpeed;
        }
        if (KeyData.HasFlag(Keys.Left))
        {
            bluePoint.X -= normalSpeed;
        }
        if (KeyData.HasFlag(Keys.Right))
        {
            bluePoint.X += normalSpeed;
        }
    
        if (KeyData.HasFlag(Keys.W))
        {
            redPoint.Y -= normalSpeed;
        }
        if (KeyData.HasFlag(Keys.S))
        {
            redPoint.Y += normalSpeed;
        }
        if (KeyData.HasFlag(Keys.A))
        {
            redPoint.X -= normalSpeed;
        }
        if (KeyData.HasFlag(Keys.D))
        {
            redPoint.X += normalSpeed;
        }
    
        Refresh();
        return true;
    
    }
