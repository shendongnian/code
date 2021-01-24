    DateTime _timeElapsed;
    TimeSpan _timePaused;
    DateTime? _pauseStart;
    protected override void Update(GameTime gameTime)
    {
        ...
               if (keyboard.IsKeyDown(Keys.P))
               {
                  if (_isPaused)
                  {
                      _timePaused += DateTime.Now - _pauseStart;
                      _pauseStart = null;
                  }
                  else
                  {
                      _pauseStart = DateTime.Now;
                  }
               }
