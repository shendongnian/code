    public sealed class DateRangeAttribute : RangeAttribute
    {
        public override bool IsValid(object value)
        {
            return ((DateTime)value < Convert.ToDateTime(Maximum)) 
                   && (DateTime)value > Convert.ToDateTime(Minimum);
        }
    }
