    public class Parent
    {
      [CompareChildDates]
      public DateTime Time { get; set; }
      public List<Child> Children { get; set; } 
    }
    public class Child
    {
      public DateTime Time { get; set; }
    }
    public class CompareChildDatesAttribute : ValidationAttribute
    {
      protected override ValidationResult IsValid(object value, ValidationContext context)
      {
        if (context.ObjectInstance is Parent parent 
          && value is DateTime parentTime
          && parent.Children.All(child => parentTime >= child.Time))
        {
          return ValidationResult.Success;
        }
        return new ValidationResult("Validation Error Message");
      }
    }
