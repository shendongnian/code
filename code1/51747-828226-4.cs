    public abstract class Drawable {
        // my game is 2d, so I use a Point to draw...
        public Point Coordinates { get; set; }
        // But I usually store my game state in a Vector2,
        // so I need a convenient way to convert. If this
        // were an interface, I'd have to write this code everywhere
        public void SetPosition(Vector2 value) {
            Coordinates = new Point((int)value.X, (int)value.Y);
        }
        // This is overridden by subclasses like AnimatedSprite and ParticleEffect
        public abstract void Draw(SpriteBatch spriteBatch, Rectangle visibleArea);
    }
