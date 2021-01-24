    public class Translation
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string TranslatedText { get; set; }
        public Translation()
        {
        }
        public IEnumerable<Translation> ReadTranslationFile(string TranslationFileName)
        {
            var translations = new List<Translation>();
            //implement reading in text file
            return translations;
        }
        public void WriteTranslationFile(string TranslationFileName, List<Translation> Translations)
        {
            //implement writing file
        }
    }
