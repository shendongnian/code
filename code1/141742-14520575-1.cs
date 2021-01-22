    // multiple ways of incrementing ballspeeds X coordinate.
    ballSprite.Position += Vector2.UnitX;
    ballSprite.Position += new Vector2(1, 0);
    ballSprite.Position = new Vector2(ballSprite.Position.X + 1, ballSprite.Position.Y);
    
    Vector2 temp = ballSprite.Position;
    temp.X++;
    ballSprite.Position = temp;
