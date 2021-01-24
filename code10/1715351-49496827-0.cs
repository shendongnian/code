    public abstract class PopulationUnit<T>:IPopulationUnit<T>
    {
        public abstract IPopulationUnit<T> Breed();
    }
    class StringUnit : PopulationUnit<string>
    {        
        public override IPopulationUnit<string> Breed()
        {
            return new StringUnit(); 
        }
    }
