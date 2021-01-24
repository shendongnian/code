    public enum PhraseType
    {
        English,
        Spanish
    }
    public abstract class Phrase
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public PhraseType PhraseType { get; set; }
    }
    public class EnglishPhrase : Phrase {}
    public class SpanishPhrase : Phrase {}
