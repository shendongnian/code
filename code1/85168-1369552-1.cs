    public class DateAttribute : ValidationAttribute
        {
    
            public override bool IsValid(object value)
            {
                var date = (string)value;
                DateTime result;
                return DateTime.TryParse(date, out result);
            }
        }
