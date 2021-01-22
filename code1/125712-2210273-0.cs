    // everything in the game (creature, item, hero, etc.) derives from this
    public class Entity {}
    // every action that can be performed derives from this
    public abstract class Command
    {
        public abstract void Perform(Entity source, Entity target);
    }
    // these are the capabilities an entity may have. these are how the Commands
    // interact with entities:
    public interface IDamageable
    {
        void TakeDamage(int amount);
    }
    public interface IOpenable
    {
        void Open();
    }
    public interface IMoveable
    {
        void Move(int x, int y);
    }
