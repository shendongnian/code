    public interface IWordService
    {
        IEnumerable<String> Words { get; }
        bool WordWasNotSubmittedPreviously(string word);
        bool WordMatchesLettersInLongWord(string longWord, string containedWordCandidate);
        void AddWordToList(string word);
    }
    public class WordService : IWordService
    {
        private List<string> _words;
        public IEnumerable<string> Words => _words;
        public WordService()
        {
            _words = new List<string>();
        }
        public bool WordWasNotSubmittedPreviously(string containedWordCandidate) => !_words.Contains(containedWordCandidate);
        public bool WordMatchesLettersInLongWord(string longWord, string containedWordCandidate)
        {
            if (string.IsNullOrWhiteSpace(containedWordCandidate)) return false;
            return containedWordCandidate.All(letter => longWord.Contains(letter));
        }
        public void AddWordToList(string word)
        {
            _words.Add(word);
        }
    }
