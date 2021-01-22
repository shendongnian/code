    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification = "We want it to be accessible via method on parent.")]
    [SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "We want users to be able to extend this class")]
    internal sealed class DateRangeAttribute : ValidationAttribute
    {
        public DateTime Minimum { get; }
        public DateTime Maximum { get; }
        public DateRangeAttribute(string format, string minimum = null, string maximum = null)
        {
            format = format ?? @"yyyy-MM-dd'T'HH:mm:ss.FFFK"; //iso8601
            Minimum = minimum == null ? DateTime.MinValue : DateTime.ParseExact(minimum, new[] { format }, CultureInfo.InvariantCulture, DateTimeStyles.None); //0 invariantculture
            Maximum = maximum == null ? DateTime.MaxValue : DateTime.ParseExact(maximum, new[] { format }, CultureInfo.InvariantCulture, DateTimeStyles.None); //0 invariantculture
            if (Minimum > Maximum)
                throw new InvalidOperationException($"Specified max-date '{maximum}' is less than the specified min-date '{minimum}'");
        }
        //0 the sole reason for employing this custom validator instead of the mere rangevalidator is that we wanted to apply invariantculture to the parsing instead of
        //  using currentculture like the range attribute does    this is immensely important in order for us to be able to dodge nasty hiccups in production environments
        public override bool IsValid(object value)
        {
            if (value == null) //0 null
                return true;
            var s = value as string;
            if (s != null && string.IsNullOrEmpty(s)) //0 null
                return true;
            var min = (IComparable)Minimum;
            var max = (IComparable)Maximum;
            return min.CompareTo(value) <= 0 && max.CompareTo(value) >= 0;
        }
        //0 null values should be handled with the required attribute
        public override string FormatErrorMessage(string name) => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, Minimum, Maximum);
    }
