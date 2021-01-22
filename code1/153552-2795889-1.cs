    int bw = 2; // Border width
    spriteBatch.Draw(t, new Rectangle(r.Left, r.Top, bw, r.Height), Color.Black); // Left
    spriteBatch.Draw(t, new Rectangle(r.Right, r.Top, bw, r.Height), Color.Black); // Right
    spriteBatch.Draw(t, new Rectangle(r.Left, r.Top, r.Width , bw), Color.Black); // Top
    spriteBatch.Draw(t, new Rectangle(r.Left, r.Bottom, r.Width, bw), Color.Black); // Bottom
