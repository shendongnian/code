    public enum Property { Name, Age, DateOfBirth};
    
    public T GetProperty<T>(Property property)
    {
        switch (property)
        {
           case Property.Name:
              return this.Name;
           // etc.
        }
    }
