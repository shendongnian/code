    class Grid
    {
        Tile[,] grid;
        void Draw(GraphicsDevice graphics)
        {
            // call your tiles Draw()
        }
    }
    class Tile
    {
        List<Sprite> sprites;
        void Draw(GraphicsDevice graphics, int x, int y)
        {
            // call your sprites Draw()
        }
    }
    class Sprite
    {
        Vector2 offset;
        Texture2D texture; // or texture and rectangle, or whatever
        void Draw(GraphicsDevice graphics, int x, int y)
        {
            // draw the sprite to graphics using x, y, offset and texture
        }
    }
