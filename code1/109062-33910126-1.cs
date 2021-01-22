    public static class EnumTranslator
    {
        private static Dictionary<TheirGender, MyGender> GenderTranslator = InitializeGenderTranslator();
        private static Dictionary<TheirGender, MyGender> InitializeGenderTranslator()
        {
            var translator = new Dictionary<TheirGender, MyGender>();
            translator.Add(TheirGender.Male, MyGender.Male);
            translator.Add(TheirGender.Female, MyGender.Female);
            translator.Add(TheirGender.Unknown, MyGender.Unknown);
            return translator;
        }
        public static MyGender Translate(this TheirGender theirValue)
        {
            return GenderTranslator[theirValue];
        }
        public static TheirGender Translate(this MyGender myValue)
        {
            return GenderTranslator.FirstOrDefault(x => x.Value == myValue).Key;
        }
        
    }
