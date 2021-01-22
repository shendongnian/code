    public T InstantiateType<T>(string firstName, string lastName) where T : IPerson, new()
        {
            T obj = new T();
            obj.FirstName = firstName;
            obj.LastName = lastName;
            return obj;
        }
