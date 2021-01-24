    public class DateRangeValidator : IValidateParameter<DateRange>
    {
        private readonly Predicate<DateTime> _isNotMinValue = x => x != DateTime.MinValue;
        private readonly Predicate<DateRange> _startIsBeforeEnd = x => x.Start < x.End;
        public bool IsValid(DateRange dateRange) => 
                                _isNotMinValue(dateRange.Start) &&
                               _isNotMinValue(dateRange.End) &&
                               _startIsBeforeEnd(dateRange);
    }
