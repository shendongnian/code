    interface IExtendedData
    {
        string GetMoreData<T>();
    }
    
    class ExtendedAnimal: Animal, IExtendedData
    {
        public virtual string GetMoreData<T>()
        { 
            if (typeof(T) == typeof(Animal))
                return "Extra animal data";
            return String.Empty;
        }
    }
    
    class ExtendedMammal: Mammal, IExtendedData
    {
        public override string GetMoreData<T>()
        { 
            if (typeof(T) == typeof(Mammal))
                return "Extra mammal data";
    
            return base.GetMoreData<Animal>();
        }
    }
    
    class ExtendedLion: Lion, IExtendedData
    {
        public override string GetMoreData<T>()
        { 
            if (typeof(T) == typeof(Lion))
                return "Extra lion data";
    
            return base.GetMoreData<Mammal>();
        }
    }
