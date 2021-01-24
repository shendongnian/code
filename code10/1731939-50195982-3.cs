    public abstract class RailwayUser
    {
        private string className;
    
        public RailwayUser()
        {
            Type type = this.GetType();
            className = type.Name;
        }
    
        public void PrintClassName()
        {
            Console.WriteLine(className);
        }
    
        public abstract void Notice(Colour state);
    }
    
