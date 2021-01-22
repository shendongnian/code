    Vector2 initialPosition = Vector2.Zero;
    Vector2 initialVelocity = new Vector2(10, 10); // Choose values that work for you
    Vector2 acceleration = new Vector2(0, -9.8f);
    float time = 0;
    Vector2 position = Vector2.Zero; // Use this when drawing your sprite
    public override void Update(GameTime gameTime)
    {
        time += (float)gameTime.ElapsedGameTime.TotalSeconds;
        position = initialPosition + initialVelocity * time
                   + 0.5f * acceleration * time * time;
    }
