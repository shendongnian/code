    public class Entity {...}
    
    public class Body : Entity
    {
      public Body(Entity sourceEntity) { this.Pointer = sourceEntity.Pointer; }
    }
