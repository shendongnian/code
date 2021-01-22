    public class LanguageModel
    {
        public string Language { get; set; }
        public IEnumerable<SelectListItem> LanguageOptions
        {
            get
            {
                return new[] 
                {
                    new SelectListItem { Value = "en", Text = "English" },
                    new SelectListItem { Value = "fr", Text = "French" },
                };
            }
        }
    }
