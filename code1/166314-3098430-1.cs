    Vector2 position;
    Vector2 velocity;
    protected override void Update(GameTime gameTime)
    {
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        if((IsInsideLeftBat(position) && velocity.X <= 0)
                || IsInsideRightBat(position) && velocity.X >= 0)
        {
            velocity.X = -velocity.X; // Bounce the other way
            // To change things up, maybe you can change velocity.Y too.
        }
        // And of course handle the ball going out of the play field, scoring, etc...
    }
