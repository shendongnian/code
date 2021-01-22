    // where integertype is int or long etc
    integertype startPress = 0;
    public void RotateBlocks(loadBlock lb, KeyboardState newState, GameTime gameTime) {
    
        _elapsedSeconds2 += (float)gameTime.ElapsedGameTime.TotalSeconds;
    
      if (lb._name.Equals("block1"))
            {
                if (newState.IsKeyDown(Keys.Up) && !oldState.IsKeyDown(Keys.Up))
                {
                    // the player just pressed Up
    startPress = GameTime.ElapsedGameTime.TotalSeconds;
    
                    if (_rotated)
                    {
                        lb._position[0].X -= 16;
                        lb._position[0].Y -= 16;
                        lb._position[2].X += 16;
                        lb._position[2].Y += 16;
                        lb._position[3].X += 32;
                        lb._position[3].Y += 32;
                        _rotated = false;
                    }
    
                    else if (!_rotated)
                    {
                        lb._position[0].X += 16;
                        lb._position[0].Y += 16;
                        lb._position[2].X -= 16;
                        lb._position[2].Y -= 16;
                        lb._position[3].X -= 32;
                        lb._position[3].Y -= 32;
                        _rotated = true;
                    }
    
    
                }
                if (newState.IsKeyDown(Keys.Up) && oldState.IsKeyDown(Keys.Up))
                {
                    // the player is holding the key down
                    if (gameTime.ElapsedGameTime.TotalSeconds - startPress >=1)
                    {
                        if (_rotated)
                        {
                            lb._position[0].X -= 16;
                            lb._position[0].Y -= 16;
                            lb._position[2].X += 16;
                            lb._position[2].Y += 16;
                            lb._position[3].X += 32;
                            lb._position[3].Y += 32;
                            _rotated = false;
                        }
    
                        else if (!_rotated)
                        {
                            lb._position[0].X += 16;
                            lb._position[0].Y += 16;
                            lb._position[2].X -= 16;
                            lb._position[2].Y -= 16;
                            lb._position[3].X -= 32;
                            lb._position[3].Y -= 32;
                            _rotated = true;
    
                        }
                        _elapsedSeconds2 = 0;
                    }
    
                }
