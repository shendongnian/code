    public struct Entity : IEquatable<Entity>
    {
        public bool Equals(Entity other)
        {
            throw new NotImplementedException("Your equality check here...");
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;
            return Equals((Entity)obj);
        }
        public static bool operator ==(Entity e1, Entity e2)
        {
            return e1.Equals(e2);
        }
        public static bool operator !=(Entity e1, Entity e2)
        {
            return !(e1 == e2);
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException("Your lightweight hashing algorithm, consistent with Equals method, here...");
        }
    }
