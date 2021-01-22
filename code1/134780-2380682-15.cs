    // S == source type
    // T == target type
    public interface IConvert<S>
    {
        // consumers\infrastructure may now add support
        int AddConversion<T> (Func<S, T> conversion);
        // gets conversion method for local consumption
        Func<S, T> GetConversion<T> ();
        // easy to use, linear look up for one-off conversions
        T To<T> (S value);
    }
    public class Convert<S> : IConvert<S>
    {
        private class ConversionRule
        {
            public Type SupportedType { get; set; }
            public Func<S, object> Conversion { get; set; }
        }
        private readonly List<ConversionRule> _map = new List<ConversionRule> ();
        private readonly object _syncRoot = new object ();
        public void AddConversion<T> (Func<S, T> conversion)
        {
            lock (_syncRoot)
            {
                if (_map.Any (c => c.SupportedType.Equals (typeof (T))))
                {
                    throw new ArgumentException (
                        string.Format (
                        "Conversion from [{0}] to [{1}] already exists. " +
                        "Cannot add new conversion.", 
                        typeof (S), 
                        typeof (T)));
                }
                ConversionRule conversionRule = new ConversionRule
                {
                    SupportedType = typeof(T),
                    Conversion = (s) => conversion (s),
                };
                _map.Add (conversionRule);
            }
        }
        public Func<S, T> GetConversion<T> ()
        {
            Func<S, T> conversionMethod = null;
            lock (_syncRoot)
            {
                ConversionRule conversion = _map.
                    SingleOrDefault (c => c.SupportedType.Equals (typeof (T)));
                if (conversion == null)
                {
                    throw new NotSupportedException (
                        string.Format (
                        "Conversion from [{0}] to [{1}] is not supported. " + 
                        "Cannot get conversion.", 
                        typeof (S), 
                        typeof (T)));
                }
                conversionMethod = 
                    (value) => ConvertWrap<T> (conversion.Conversion, value);
            }
            return conversionMethod;
        }
        public T To<T> (S value)
        {
            Func<S, T> conversion = GetConversion<T> ();
            T typedValue = conversion (value);
            return typedValue;
        }
        // private methods
        private T ConvertWrap<T> (Func<S, object> conversion, S value)
        {
            object untypedValue = null;
            try
            {
                untypedValue = conversion (value);
            }
            catch (Exception exception)
            {
                throw new ArgumentException (
                    string.Format (
                    "Unexpected exception encountered during conversion. " +
                    "Cannot convert [{0}] [{1}] to [{2}].",
                    typeof (S),
                    value,
                    typeof (T)),
                    exception);
            }
            if (!(untypedValue is T))
            {
                throw new InvalidCastException (
                    string.Format (
                    "Converted [{0}] [{1}] to [{2}] [{3}], " +
                    "not of expected type [{4}]. Conversion failed.",
                    typeof (S),
                    value,
                    untypedValue.GetType (),
                    untypedValue,
                    typeof (T)));
            }
            T typedValue = (T)(untypedValue);
            return typedValue;
        }
    }
