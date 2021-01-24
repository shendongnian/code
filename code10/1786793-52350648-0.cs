    public class Key
    {
        public Key(decimal unitPoints, List<TranslationData> texts)
        {
            UnitPoints = unitPoints;
            Texts = texts;
        }
        public decimal UnitPoints { get; set; }
        public List<TranslationData> Texts { get; set; }
    }
