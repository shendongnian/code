    private class Reporting
    {
        private IEnumerable<IOptionFactory<IOption>> _allOptionsFactories;
        public Reporting(IEnumerable<IOptionFactory<IOption>> allOptionsFactories)
        {
            if (allOptionsFactories == null)
            {
                throw new ArgumentNullException("Parameter:" + nameof(allOptionsFactories));
            }
            this._allOptionsFactories = allOptionsFactories;
        }
        public void Report()
        {
            foreach (var optionsFactories in _allOptionsFactories)
            {
                Console.WriteLine(optionsFactories.GetType());
            }
        }
    }
