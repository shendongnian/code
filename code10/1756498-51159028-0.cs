    Indicator {
        // other indicator fields
        public virtual List<Translation> SomeText1Translations
        public virtual List<Translation> SomeText2Translations
    }
    
    Measure {
        // other measure fields
        public virtual List<Translation> SomeText3Translations
        public virtual List<Translation> SomeText4Translations
    }
    
    Translation {
        Int TranslationID
        String LanguageCode
        String Text
        // Use inverse attributes or fluent code to tell EF how to connect relationships
        [InverseProperty("SomeText1Translations")]
        public virtual ICollection<Indicator> TranslationForIndicatorText1 { get; set; }
        [InverseProperty("SomeText2Translations")]
        public virtual ICollection<Indicator> TranslationForIndicatorText2 { get; set; }
        [InverseProperty("SomeText3Translations")]
        public virtual ICollection<Measure> TranslationForMeasureText3 { get; set; }
        [InverseProperty("SomeText4Translations")]
        public virtual ICollection<Measure> TranslationForMeasureText4 { get; set; }
    }
