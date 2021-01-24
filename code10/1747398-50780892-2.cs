    public abstract class EntityBase
    {
        protected virtual object Keys { get { return this; } }
        protected virtual object EmptyKeys {get { return null;} }
        public override bool Equals(object obj)
        {
          if (Keys == this) return base.Equals(obj);
          var entity = obj as EntityBase;
          if (entity == null) return false;
          var re = ReferenceEquals(entity, this);
          return re || GetType() == entity.GetType() && Equals(entity.Keys, Keys) && !Equals(Keys, EmptyKeys);
        }
        public override int GetHashCode()
        {
          if (Keys == this) return base.GetHashCode();
          return base.GetHashCode() * 17 + (Keys?.GetHashCode() ?? 0);
        }
    }
