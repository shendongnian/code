    private bool check = false;
    protected override Update(GameTime gameTime)
    {
        if(!check)
        {    
            check = true;
            HandleCollisions();
        }
    }
    
    protected override Draw(GameTime gameTime)
    {
        check = false;
    }
