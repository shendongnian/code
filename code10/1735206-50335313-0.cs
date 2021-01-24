    public class LetterFactory : ILetterFactory
    {
        private readonly IIndex<Int32, Func<LetterBase>> _lettersFactory; 
        public LetterFactory(IIndex<Int32, Func<LetterBase>> lettersFactory)
        {
            _lettersFactory = lettersFactory;
        }
        public LetterBase Create(int letterId)
        {
            if (letterId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(letterId));
            }
            
            Func<LetterBase> letterFactory = null; 
            if(!this._lettersFactory.tryGetValue(letterId, out letterFactory))
            {
                string message = $"Could not find a LetterBase to create for id {letterId}.";
                throw new NotSupportedException(message);        
            }
            
            Letter letter = letterFactory(); 
            return letter; 
        }
    }
