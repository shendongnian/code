    int timeElapsed = 0;
    protected override void Update(GameTime gameTime)
    {
        //...
        if (keyboard.IsKeyDown(Keys.P))
        {
           isPaused = !isPaused;
        }
        if (!isPaused)
        {
            timeElapsed += gameTime.ElapsedGameTime.Milliseconds;
            //code when the game isn't paused.
        }
        else
        {
            //code when the game is paused.
        }
    }
