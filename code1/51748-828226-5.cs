    public class ListDrawable : Drawable {
        private List<Drawable> Children;
        // ...
        public override void Draw(SpriteBatch spriteBatch, Rectangle visibleArea) {
            if (Children == null) {
                return;
            }
            foreach (Drawable child in children) {
                child.Draw(spriteBatch, visibleArea);
            }
        }
    }
