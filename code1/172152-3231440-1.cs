    public void Draw()
    {
        spriteBatch.Begin();
    
        DrawPaddles(spriteBatch);
        DrawBall(spriteBatch);
    
        // this being the line that answers your question
        spriteBatch.DrawString(scoreFont, playerScore.ToString(), new Vector2(10, 10), Color.White);
    
        spriteBatch.End();
    }
