    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        for (int i = 0; i < grid.GetLength(1); i++)//width
        {
            for (int j = 0; j < grid.GetLength(0); j++)//height
            {
                int textureIndex = grid[j, i];
                if (textureIndex == -1)
                    continue;
                Texture2D texture = tileTextures[textureIndex];//list of textures
                spriteBatch.Draw(texture, new Rectangle(
                    i * 60, j * 60, 60, 60), Color.White);
            }
        }
        spriteBatch.End();
    }
