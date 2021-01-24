    public class TranslationCollection : List<Translation>
    {
        public Translation GetTranslationForLanguage(int languageId)
        {
            return this.FirstOrDefault(x => x.LanguageId == languageId) ?? this.FirstOrDefault(x=> x.LanguageId == 0);
        }
        public string GetCaptionForLanguage(int languageId)
        {
            var translation = this.FirstOrDefault(x => x.LanguageId == languageId) ?? this.FirstOrDefault(x=> x.LanguageId == 0);
            return translation == null ? "" : translation.Caption;
        }
    }
    public class Translation
    {
        public int LanguageId { get; set; }
        public string Caption { get; set; }
    }
