    class GameObject
    { 
      private List<GameComponent> _components = new List<GameComponent>();
      
      public T GetComponent<T>(string name) where T : GameComponent, new
      {
        return
          (from c in _components.OfType<T>()
          where c == new T { Name = name }
          select c).FirstOrDefault();
      }
    } 
    
    class GameComponent
    {
      public string Name { get; set; }
      public bool Equals(GameComponent other)
      {
        if (ReferenceEquals(null, other))
        {
          return false;
        }
        if (ReferenceEquals(this, other))
        {
          return true;
        }
        return Equals(other.Name, Name);
      }
      public override bool Equals(object obj)
      {
        if (ReferenceEquals(null, obj))
        {
          return false;
        }
        if (ReferenceEquals(this, obj))
        {
          return true;
        }
        if (obj.GetType() != typeof(GameComponent))
        {
          return false;
        }
        return Equals((GameComponent)obj);
      }
      public override int GetHashCode()
      {
        return (Name != null ? Name.GetHashCode() : 0);
      }
    }
