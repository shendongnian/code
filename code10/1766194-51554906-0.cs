    public class Company
    {
        // ...
        public Company DuplicateOf { get; set; }
  
        // May be useful, hides check for duplicate logic:
        public bool IsDuplicate => DuplicateOf != null;
        // May be useful as well, 
        // returns the non-duplicate uniue company, not a duplicate, either linked or current:
        public Company EffectiveCompany => DuplicateOf ?? this;
    }
