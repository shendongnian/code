    public interface ICollidable
    {
        void OnCollision();
    }
    public abstract class Body : ICollidable
    {
        public abstract void OnCollision();
    }
    public class Dog : Body
    {
        public override void OnCollision();
        {
            Bark();
        }
    }
    public Boolean OnCollision(ICollidable a, ICollidable b)
    {
        b.OnCollision();
    }
