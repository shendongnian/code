    //add this to your public variables
    public Texture2D currentTexture = null;
    // Load
    public void LoadContent(ContentManager Content)
    {
        texture  = Content.Load<Texture2D>("playerShip");
        texture2 = Content.Load<Texture2D>("playerShip2");
        currentTexture = texture;
    }
    // Update
    public void Update(GameTime gameTime)
    {
        KeyboardState curKeyboardState = Keyboard.GetState();
        if (curKeyboardState.IsKeyDown(Keys.W))
        {
            currentTexture = texture2;
        }
        //...
    }
    // Draw
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(currentTexture, position, Color.White);
    }
