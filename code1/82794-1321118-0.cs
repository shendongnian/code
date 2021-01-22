    public int GetHashCode(T obj) {
        if (obj == null) {
            throw new ArgumentNullException("obj");
        }
        return obj.Guid.GetHashCode();
    }
