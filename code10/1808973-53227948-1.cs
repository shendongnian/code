    public class BookDto
    {
        public string Name { get; set; }
        public IList<BookChapterDto> Chapters { get; set; }
    }
    public class BookChapterDto
    {
        public string Name { get; set; }
    }
