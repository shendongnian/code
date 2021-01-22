    private Type entityType;
    public Type EntityType {
        get {return entityType;}
        set {
            if(!typeof(IEntity).IsAssignableFrom(value)) {
                throw new ArgumentException("EntityType must implement IEntity");
            }
            entityType = value;
        }
    }
