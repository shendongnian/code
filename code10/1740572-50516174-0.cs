    public class Category : Entity
    {
        public int Value { get; set; }
        public bool AutoTranslate { get; set; }
        public List<CategoryTranslation> Translations { get; set; }
    }
    public class CategoryTranslation : Entity
    {
        public string Name { get; set; }
        public bool PrimaryTranslation { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
    public class Language : Entity
    {
        public string Country { get; set; }
        public string Code { get; set; }
        public bool? IsPrimary { get; set; }
        public bool IsActive { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
