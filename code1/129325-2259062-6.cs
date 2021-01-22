    [HasSelfValidation]
    public class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
    
        [SelfValidation]
        public void ValidateRange(ValidationResults results)
        {
            if (this.Max < this.Min)
            {
                results.AddResult(
                    new ValidationResult("Max less than min", this, "", "", null));
            }
        }
    }
