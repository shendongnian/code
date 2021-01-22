    public abstract class Entity {
        public Guid Id {get; set;}
        public int Version {get; set;}
    }
    public abstract class Entity<T> : Entity where T : Entity<T> {
        public T Clone() {
            ...
            // clone routine
            ...
            return T;
        }
    }
