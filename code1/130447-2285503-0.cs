        public interface IEatable {}
        class Vegitable : IEatable 
        { string Name { get; set; } }
        class Fruit : IEatable 
        { string Name { get; set; } }
        public interface IEatableManager
        {
            List<Vegitables> LoadEatables(string filePath);
        }
        public class VetabaleManager : IEatableManager
        {
            #region IEatableManagerMembers    
            public List<Vegitable> LoadVegs(string filePath)
            {
                throw new NotImplementedException();
            }    
            #endregion
        }
        .
        .
        .
