	public class ModifyPosition : Modifier
    {
        public ModifyPosition(Vector2 position)
        {
            Position = position;
        }
        public Vector2 Position { get; private set; }
        
        public override void Apply(object entity)
        {
			if (!(entity is IPositionableEntity))
			{
				return; //throw, whatever
			}
        	var positionableEntity = (IPositionableEntity) entity;
            positionableEntity.Position.X += Position.X;
            positionableEntity.Position.Y += Position.Y;
        }
    }
