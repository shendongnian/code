    public IEnumerable<Foo> GetFoos()
    {
        return Array.AsReadOnly(this.foos);
        // or if it is a List<T>
        // return this.foos.AsReadOnly();
    }
