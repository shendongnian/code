        public interface IPopulationUnit<T, T1> where T1 : IPopulationUnit<T, T1>
        {
            T1 Breed();
        }
        public abstract class PopulationUnit<T> : IPopulationUnit<T, PopulationUnit<T>>
        {
            public abstract PopulationUnit<T> Breed();
        }
        
        class StringUnit : PopulationUnit<string>
        {
            public override PopulationUnit<string> Breed()
            {
                return new StringUnit();
            }
        }
