    public class CosmosCriteria 
    {
        public CosmosCriteria()
        {
            ContainsValues = new List<string>();
        }
        public CosmosCriteriaType CriteriaType { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public ConvertedRuleComparitor Comparitor { get; set; }
        public DateRange Dates { get; set; }
        public List<string> ContainsValues { get; set; }
    }
