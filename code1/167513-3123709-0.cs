    public class SectionItemParameters
    {
        public string Title { get; set; }
    }
    public class SectionItemLessonParameters
        : SectionItemParameters
    {
        public int SectionNumber { get; set; }
        public DateTime StartDate { get; set; }
        public List<Flashcard> Flashcards { get; set; }
    }
    public class SectionItemInfoParameters
        : SectionItemParameters
    {
        public string Content { get; set; }
    }
