    public interface IPositionableEntity
    {
        Vector2 Position { get; set; }
    }
    public class Entity
    {
        public void ApplyModifier<T>(T modifier) where T : Modifier 
        {
            modifier.Apply(this);
        }
    }
    public class Entity2D : Entity, IPositionableEntity
    {
        public Vector2 Position { get; set; }
    }
	public class Vector2
	{
		public double X { get; set; }
		public double Y { get; set; }
	}
	public abstract class Modifier
	{
        public abstract void Apply<T>(T entity);
    }
    public class ModifyPosition : Modifier
    {
        public ModifyPosition(Vector2 position)
        {
            Position = position;
        }
        public Vector2 Position { get; private set; }
        
        //Compiler error here:
        //Constraints for explicit interface implementation method are inherited
        //from the base method, so they cannot be specified directly
        public override void Apply<T>(T entity) where T : IPositionableEntity
        {
            entity.Position.X += Position.X;
            entity.Position.Y += Position.Y;
        }
    }
