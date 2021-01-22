    public ReflectionSodaCreator : ISodaCreator
    {
        private readonly ConstructorInfo constructor;
        public string Name { get; private set; }
    
        public ReflectionSodaCreator(string name, ConstructorInfo constructor)
        {
            this.Name = name;
            this.constructor = constructor;
        }
    
        public ISoda CreateSoda()
        {
            return (ISoda)this.constructor.Invoke(new object[0])
        }
    }
