    public enum Range
    {
        /// <summary>
        /// A range that contains all values greater than start and less than end.
        /// </summary>
        Open,
        /// <summary>
        /// A range that contains all values greater than or equal to start and less than or equal to end.
        /// </summary>
        Closed,
        /// <summary>
        /// A range that contains all values greater than or equal to start and less than end.
        /// </summary>
        OpenClosed,
        /// <summary>
        /// A range that contains all values greater than start and less than or equal to end.
        /// </summary>
        ClosedOpen
    }
    public static class RangeExtensions
    {
        /// <summary>
        /// Checks if a value is within a range that contains all values greater than start and less than or equal to end.
        /// </summary>
        /// <param name="value">The value that should be checked.</param>
        /// <param name="start">The first value of the range to be checked.</param>
        /// <param name="end">The last value of the range to be checked.</param>
        /// <returns><c>True</c> if the value is greater than start and less than or equal to end, otherwise <c>false</c>.</returns>
        public static bool IsWithin<T>(this T value, T start, T end) where T : IComparable<T>
        {
            return IsWithin(value, start, end, Range.ClosedOpen);
        }
        /// <summary>
        /// Checks if a value is within the given range.
        /// </summary>
        /// <param name="value">The value that should be checked.</param>
        /// <param name="start">The first value of the range to be checked.</param>
        /// <param name="end">The last value of the range to be checked.</param>
        /// <param name="range">The kind of range that should be checked. Depending on the given kind of range the start end end value are either inclusive or exclusive.</param>
        /// <returns><c>True</c> if the value is within the given range, otherwise <c>false</c>.</returns>
        public static bool IsWithin<T>(this T value, T start, T end, Range range) where T : IComparable<T>
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            if (end == null)
                throw new ArgumentNullException(nameof(end));
            switch (range)
            {
                case Range.Open:
                    return value.CompareTo(start) > 0
                           && value.CompareTo(end) < 0;
                case Range.Closed:
                    return value.CompareTo(start) >= 0
                           && value.CompareTo(end) <= 0;
                case Range.OpenClosed:
                    return value.CompareTo(start) > 0
                           && value.CompareTo(end) <= 0;
                case Range.ClosedOpen:
                    return value.CompareTo(start) >= 0
                           && value.CompareTo(end) < 0;
                default:
                    throw new ArgumentException($"Unknown parameter value {range}.", nameof(range));
            }
        }
    }
