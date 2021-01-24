        public bool CanSeePlayer()
        {
            Vector2 middleOfPlayer = new Vector2(Level.Player.Position.X, Level.Player.Position.Y - Level.Player.BoundingRectangle.Height / 2);
            Vector2 middleOfEnemy = new Vector2(Position.X, Position.Y - localBounds.Height / 2);
            Vector2 direction = middleOfPlayer - middleOfEnemy;
            float distanceToPlayer = Vector2.Distance(middleOfEnemy, middleOfPlayer);
            if (visionLength > distanceToPlayer) // If the enemy can see farther than the player's distance,
            {
                if (direction != Vector2.Zero)
                direction.Normalize();
                for (int y = 0; y < Level.tiles.GetLength(1); ++y) // loop through every tile, 
                {
                    for (int x = 0; x < Level.tiles.GetLength(0); ++x)
                    {
                        if (Level.GetCollision(x, y) != TileCollision.Passable) // and if the block is solid,
                        {
                            Vector2 currentPos = middleOfEnemy;
                            float lengthOfLine = 0.0f;
                            Rectangle tileRect = new Rectangle(x * Tile.Width, y * Tile.Height, Tile.Width, Tile.Height);
                            while (lengthOfLine < distanceToPlayer + 1.0f) // check every point along the line
                            {
                                currentPos += direction;
                                if (tileRect.Contains(currentPos)) // to see if the tile contains it.
                                {
                                    return false;
                                }
                                lengthOfLine = Vector2.Distance(middleOfEnemy, currentPos);
                            }
                        }
                    }
                }
                // If every tile does not contain a single point along the line from the enemy to the player,
                return true;
            }
            return false;            
        }
