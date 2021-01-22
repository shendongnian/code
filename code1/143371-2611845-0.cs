    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Set width, height
        const int WIDTH = 800;
        const int HEIGHT = 600;
        // Used to randomly fill in initial data, not necessary
        Random rand;
        // Graphics and spritebatch
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // Texture you will regenerate each call to update
        Texture2D texture;
        // Data array you perform calculations on
        uint[] data;
        // Colors are represented in the texture as 0xAARRGGBB where:
        // AA = alpha
        // RR = red
        // GG = green
        // BB = blue
        // Set the first color to red
        const uint COLOR0 = 0xFFFF0000;
        // Set the second color to blue
        const uint COLOR1 = 0xFF0000FF;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Set width, height
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
        }
        protected override void Initialize()
        {
            base.Initialize();
            // Seed random, initialize array with random picks of the 2 colors
            rand = new Random((int)DateTime.Now.Ticks);
            data = new uint[WIDTH * HEIGHT];
            loadInitialData();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Create a new texture
            texture = new Texture2D(GraphicsDevice, WIDTH, HEIGHT);
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            // Run-time error without this
            // Complains you can't modify a texture that has been set on the device
            GraphicsDevice.Textures[0] = null;
            // Do the calculations
            updateData();
            // Update the texture for the next time it is drawn to the screen
            texture.SetData(data);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            // Draw the texture once
            spriteBatch.Begin();
            spriteBatch.Draw(texture, Vector2.Zero, Color.Purple);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void loadInitialData()
        {
            // Don't know where the initial data comes from
            // Just populate the array with a random selection of the two colors
            for (int i = 0; i < WIDTH; i++)
                for (int j = 0; j < HEIGHT; j++)
                    data[i * HEIGHT + j] = rand.Next(2) == 0 ? COLOR0 : COLOR1;
        }
        private void updateData()
        {
            // Rough approximation of calculations
            for(int y = HEIGHT - 1; y >= 0; y--)
                for (int x = WIDTH - 1; x >= 0; x--)
                    if (data[x * HEIGHT + y] == COLOR1)
                        if (y + 1 < HEIGHT && data[x * HEIGHT + (y + 1)] == COLOR0)
                        {
                            data[x * HEIGHT + (y + 1)] = data[x * HEIGHT + y];
                            data[x * HEIGHT + y] = COLOR0;
                        }
        }
    }
