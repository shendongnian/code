    [DateOfBirth(MinAge = 0, MaxAge = 150)]
    public DateTime DateOfBirth { get; set; }
    // ...
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            var val = (DateTime)value;
            if (val.AddYears(MinAge) > DateTime.Now)
                return false;
            return (val.AddYears(MaxAge) > DateTime.Now);
        }
    }
