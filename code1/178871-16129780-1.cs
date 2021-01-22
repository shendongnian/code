    public void drawSprite(Sprite sprite, Texture texture, Point dimension, Point rotationCenter, float rotationAngle, Point position)
        {
            sprite.Begin(SpriteFlags.AlphaBlend);
            //First draw the sprite in position 0,0 and set your desired rotationCenter (dimension.X and dimension.Y represent the pixel dimension of the texture)
            sprite.Draw(texture, new Rectangle(0, 0, dimension.X, dimension.Y), new Vector3(rotationCenter.X, rotationCenter.Y, 0), new Vector3(0, 0, 0), Color.White);
            //Then rotate the sprite and then translate it in your desired position
            sprite.Transform = Matrix.RotationZ(rotationAngle) * Matrix.Translation(position.X, position.Y, 0);
            
            sprite.End();   
        }
