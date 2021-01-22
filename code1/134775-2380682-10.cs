    // FType == from type
    // TType == to type
    public interface IConvert<FType>
    {
        // consumers\infrastructure may now add support
        int AddConversion<TType> (Func<FType, TType> conversion);
        // easy to use, linear look up
        TType Convert<TType> (FType fromValue);
        // easy to use, instant look up
        TType Convert<TType> (FType fromValue, int conversionIndex);
        // linear look up from type
        int GetConversionIndex<TType> ();
    }
    // FType = string
    // TType = method parameter
    public class StringConvert : IConvert<string>
    {
        private class ConversionRule
        {
            public Type SupportedType { get; set; }
            public Func<string, object> Conversion { get; set; }
        }
        private readonly List<ConversionRule> _map = new List<ConversionRule> ();
        private readonly object _mapSyncRoot = new object ();
        public int AddConversion<T> (Func<T, string> conversion)
        {
            int supportedTypeIndex = 0;
            lock (_mapSyncRoot)
            {
                if (_map.Any (c => c.SupportedType.Equals (typeof (T)))
                {
                    // already exists! what do we do? meh, maybe return
                    // existing index, maybe overwrite, maybe throw
                    // exception? up to you :)
                    // 
                    // actually, you probably want to add a soft means of
                    // interrogation or addition, like add a ConversionExists
                    // method, or a TryAddConversion method, and throw
                    // exception if exists
                }
                else
                {
                    ConversionRule conversionRule = new ConversionRule 
                    {
                        SupportedType = typeof (T),
                        Conversion = (s) => conversion (s),
                    };
                    _map.Add (conversionRule);
                    supportedTypeIndex = _map.Count - 1;
                }
            }
            return supportedTypeIndex;
        }
        public T Convert<T> (string stringValue)
        {
            int supportedTypeIndex = GetSupportedTypeIndex<T> ();
            T value = Convert (stringValue, supportedTypeIndex);
            return value;
        }
        public T Convert<T> (string stringValue, int supportedTypeIndex)
        {
            T value = default (T);
            ConversionRule conversionRule = null;
            lock (_mapSyncRoot)
            {
                if ((supportedTypeIndex > 0) && 
                    (supportedTypeIndex < _map.Count))
                {
                    if (_map[supportedTypeIndex].SupportedType == typeof (T))
                    {
                        conversionRule = _map[supportedTypeIndex];
                    }
                    else 
                    {
                        // oh nos! someone supplied a bad index! or type!
                    }
                }
                else 
                {
                    // arg, definitely a bad index
                }
            }
            object untypedValue = null;
            try
            {
                untypedValue = conversionRule.Conversion (stringValue);
            }
            // alright, catching all exceptions is bad, but how do you constrain
            // or set reasonable expectations on a user-submitted lambda expression?
            catch (Exception exception)
            {
                throw new ArgumentException (
                    string.Format (
                    "Cannot convert type [{0}] with value [{1}] to type [{2}]." + 
                    " Converter threw exception.",
                    stringValue.GetType (),
                    stringValue,
                    typeof (T)),
                    exception);
            }
            // NOTE: proper use of `is` operator
            if (untypedValue is T)
            {
                value = (T)(untypedValue);
            }
            else
            {
                // i think you know what to do ;)
            }
            return value;
        }
        public int GetSupportedTypeIndex<T> ()
        {
            int supportedTypeIndex = -1;
            lock (_mapSyncRoot)
            {
                // er, not sure what FindIndex returns or does if
                // operation is not successful. may have to check
                // return
                supportedTypeIndex = _map.FindIndex (
                    c => c.SupportedType.Equals (typeof (T)));
            }
            return supportedTypeIndex;
        }
    }
