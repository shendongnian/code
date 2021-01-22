You don't have to create the Texture every frame, just in LoadContent. A very stripped down version of the code from that demo:
    public class RectangleOverlay : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D dummyTexture;
        Rectangle dummyRectangle;
        Color Colori;
        public RectangleOverlay(Rectangle rect, Color colori, Game game)
            : base(game)
        {
            // Choose a high number, so we will draw on top of other components.
            DrawOrder = 1000;
            dummyRectangle = rect;
            Colori = colori;
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            dummyTexture = new Texture2D(GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { Color.White });
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(dummyTexture, dummyRectangle, Colori);
            spriteBatch.End();
        }
    }
