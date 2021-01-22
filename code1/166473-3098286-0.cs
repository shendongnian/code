    public enum LanguageName
        {
            Arabic = 1,
            Chinese,
            Dutch,
            English,
            Farsi,
            French,
            Hindi,
            Indonesian,
            Portuguese,
            Spanish,
            Urdu
        }
    
        public enum LanguageISOCode
        {
            ara = 1,
            zho,
            dut,
            eng,
            fas,
            fre,
            hin,
            ind,
            por,
            spa,
            urd
        }
    
    public class language
    {
        public language()
        {
        }
    
        public LanguageName Name
        {
            get
            {
               return (LanguageName)((int)Code);
            }
            set;
        }
    
        public LanguageISOCode Code
        {
            get;
            set;
        }
    }
