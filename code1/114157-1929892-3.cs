    interface Repository<T>{
        T Find(Predicate<T>);
        List<T> ListAll();
    }
    
    interface Gateway<T>{
        T GetFrom(IQuery query);
        void AddToDatabase(IEntity entityItem);
    }
    
    interface Settings<T>{
        string Name { get; set; }
        T Value { get; set; }
        T Default { get; }
    }
