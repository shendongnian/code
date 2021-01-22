    protected void Collision() {      
        #region Boundaries        
        if (bal.Position.X + bal.Velocity.X >= viewportRect.Width ||        
            bal.Position.X + bal.Velocity.X <= 0)        
            bal.Velocity.X *= -1;        
        if (bal.Position.Y + bal.Velocity.Y <= 0)        
            bal.Velocity.Y *= -1;        
        #endregion
        if (bal.Rect.Intersects(player.Rect)) {      
            bal.Position.Y = player.Position.Y - player.Sprite.Height/2 
                           - bal.Sprite.Height/2;      
            if (player.Position.X != player.PrevPos.X)      
                bal.Velocity.X -= (player.PrevPos.X - player.Position.X) / 2;      
            bal.Velocity.Y *= -1;      
        }      
        foreach (Brick b in brickArray.list) {      
            if (bal.Rect.Intersects(b.Rect)) {      
                b.RecieveHit();      
                bal.Velocity.Y *= -1;      
            }      
        }      
        brickArray.RemoveDead();      
    }      
