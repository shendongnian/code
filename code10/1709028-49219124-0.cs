    public class WordEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }
    
        public virtual List<WordSinonymEntity> Sinonyms { get; set; }
        public virtual List<WordSinonymEntity> SinonymOf { get; set; } // <--
    }
