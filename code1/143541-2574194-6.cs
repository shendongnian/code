    public interface ISodaCreator
    {
        string Name { get; }
        ISoda CreateSoda();
    }
    public class SodaFactory
    {
        private readonly IEnumerable<ISodaCreator> sodaCreators;
    
        public SodaFactory(IEnumerable<ISodaCreator> sodaCreators)
        {
            this.sodaCreators = sodaCreators;
        }
        public ISoda CreateSodaFromName(string name)
        {
            var creator = this.sodaCreators.FirstOrDefault(x => x.Name == name);
            // TODO: throw "unknown soda" exception if creator null here
            
            return creator.CreateSoda();
        }
    }
