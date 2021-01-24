    public interface IPopulationUnit<T, T1> where T1 : IPopulationUnit<T, T1>
    {
        T1 Breed();
    }
    
    public abstract class PopulationUnit<T, T1> : IPopulationUnit<T, T1> where T1 : PopulationUnit<T, T1>
    {
        public abstract T1 Breed();
    }
    
    public class StringUnit : PopulationUnit<string, StringUnit>
    {        
        public override StringUnit Breed()
        {
    		throw new NotImplementedException();
        }
    }
