    // only required in your test project:
    internal class SampleTest : Sample
    {
        public SampleTest(IDictionary<string, string> dictionaryToUse)
        {
            this._dictionaryToUse = dictionaryToUse;
        }
    
        private IDictionary<string, string> _dictionaryToUse;
    
        protected override IDictionary<string, string> InitializeDictionary()
        {
            return this._dictionaryToUse;
        }
    }
