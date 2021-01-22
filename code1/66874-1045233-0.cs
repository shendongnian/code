    public interface IMovable
    {
        int MovementRate { get; set; }
        void MoveTo(int x, int y);
    }
    public class Monster : Mob, IMovable
    {
        public int MovementRate { get; set; }
        public void MoveTo(int x, int y)
        {
             // ...
        }
    }
