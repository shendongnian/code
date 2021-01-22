    int bw = 2; // Border width
    var sb = spriteBatch;
    sb.Draw(t, new Rectangle(r.Left, r.Top, bw, r.Height), Color.White); // Left
    sb.Draw(t, new Rectangle(r.Right, r.Top, bw, r.Height), Color.White); // Right
    sb.Draw(t, new Rectangle(r.Left, r.Top, r.Width , bw), Color.White); // Top
    sb.Draw(t, new Rectangle(r.Left, r.Bottom, r.Width, bw), Color.White); // Bottom
