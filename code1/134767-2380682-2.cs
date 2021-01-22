    // thought it would be smart to wrap this in an extension class, it would
    // certainly be convenient. however the shared map resource is a bit of a
    // smell, this sort of functionality would likely be better off in an
    // IConverter service implementation and injected into your consumers.
    public static class StringExtensions
    {
        private class Conversion
        {
            public Type SupportedType { get; set; }
            public Func<string, object> Conversion { get; set; }
        }
        private static readonly List<Conversion> Map = new List<Conversion> ();
        private static readonly object MapSyncRoot = new object ();
        public static int AddConversion<T> (Func<T, string> conversion)
        {
            int supportedTypeIndex = 0;
            lock (MapSyncRoot)
            {
                if (Map.Any (c => c.SupportedType.Equals (typeof (T)))
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
                    Conversion conversionRule = new Conversion 
                    {
                        SupportedType = typeof (T),
                        Conversion = (s) => conversion (s),
                    };
                    Map.Add (conversionRule);
                    supportedTypeIndex = Map.Count - 1;
                }
            }
            return supportedTypeIndex;
        }
        public static T Convert<T> (this string stringValue)
        {
            int supportedTypeIndex = StringExtensions.GetSupportedTypeIndex<T> ();
            T value = stringValue (supportedTypeIndex);
            return value;
        }
        public static T Convert<T> (this string stringValue, int supportedTypeIndex)
        {
            T value = default (T);
            Conversion conversionRule = null;
            lock (MapSyncRoot)
            {
                if ((supportedTypeIndex > 0) && 
                    (supportedTypeIndex < Map.Count))
                {
                    if (Map[supportedTypeIndex].SupportedType == typeof (T))
                    {
                        conversionRule = Map[supportedTypeIndex];
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
        public static int GetSupportedTypeIndex<T> ()
        {
            int supportedTypeIndex = -1;
            lock (MapSyncRoot)
            {
                // er, not sure what FindIndex returns or does if
                // operation is not successful. may have to check
                // return
                supportedTypeIndex = Map.FindIndex (
                    c => c.SupportedType.Equals (typeof (T)));
            }
            return supportedTypeIndex;
        }
    }
