    interface ISystem
    {
        ISet<Guid> SystemEntities { get; }
        Type[] ComponentTypes { get; }
    
        void Run();
    }
    
    class DrawingSystem : ISystem
    {
        public DrawingSystem(params Type[] componentTypes)
        {
            ComponentTypes = componentTypes;
            SystemEntities = new HashSet<Guid>();
        }
    
        public ISet<Guid> SystemEntities { get; }
    
        public Type[] ComponentTypes { get; }
    
        public void Run()
        {
            foreach (var entity in SystemEntities)
            {
                Draw(entity);
            }
        }
    
        private void Draw(Guid entity) { /*Do Magic*/ }
    }
