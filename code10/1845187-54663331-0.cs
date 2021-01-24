    static void Main(string[] args)
    {
        var s = new Sprite();
        s.DoStuffWhenPositionChanges(s.Position.X++);
    }
    public struct Vector2
    {
        public float X;
        public float Y;
    }
    public class Sprite
    {
        private Vector2 position;
        public ref Vector2 Position => ref position;
        public void DoStuffWhenPositionChanges(float f = default)
        {
        }
    }
