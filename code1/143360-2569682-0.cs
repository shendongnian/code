    class GameObject {
      Point Position { get; set; } 
      Vector Velocity { get; set; }
      Sprite Sprite { get; set; }
      Rectangle Rect { 
        get { 
          // Ecnapsulated calculation of the bounding rectangle
          return new Rectangle
            ( (int)Position.X + (int)Velocity.X - Sprite.Width/2, 
              (int)Position.Y + (int)Velocity.Y - Sprite.Height/2, 
              Sprite.Width, Sprite.Height);   
        }
    }    
