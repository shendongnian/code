    public class Factories
    {
        private IEnumerable<IOptionFactory<IOption>> _allOptionFactories;
        
        public Factories(IEnumerable<IOptionFactory<IOption>> allOptionFactories)
        {
            this._allOptionFactories = allOptionFactories;
        }
        public IEnumerable<IOptionFactory<IOption>> GetFactories()
        {
             return this._allOptionFactories;
        }
    }
