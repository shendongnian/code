    public class Book 
    {
        public string Title {get; set;}
        public List<Chapter> AvailableChapters; {get;}
    
        public string AvailableChaptersDisplay
        { get {return string.Join( " ", AvailableChapters.Select( c => c.ChapterNumber )); } }
    }
