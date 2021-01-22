    virtual public void Update(float t, Camera c)
    {
        Vector2 a = new Vector2(0, PixelsPerMeter*9.8f);
        Velocity = Velocity + a * t;
        Position = Position + Velocity * t; // Like n*(n-1)/2
        Position.Y = MathHelper.Min(FloorY, Position.Y);
        Velocity.Y = (Position.Y==0.0)?MathHelper.Min(0, Velocity.Y):Velocity.Y;
    }
    
