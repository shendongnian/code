    public class Entity {
        public Vector2 Position { get; set; }
        public Drawable Drawable { get; set; }
        public void Update(double seconds) {
            // Entity Update logic...
            if (Drawable != null) {
                Drawable.Update(seconds);
            }
        }
        public void LoadContent(/* I forget the args */) {
            // Entity LoadContent logic...
            if (Drawable != null) {
                Drawable.LoadContent(seconds);
            }
        }
    }
