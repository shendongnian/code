    public enum DayOfWeek
    {
        Weekend,
        Sunday = 0,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    public class TypeNotSupportedException : ApplicationException
    {
        public TypeNotSupportedException(Type type)
            : base(string.Format("The type \"{0}\" is not supported in this context.", type.Name))
        {
        }
    }
    public class CannotBeIndexerException : ApplicationException
    {
        public CannotBeIndexerException(Type enumUnderlyingType, Type indexerType)
            : base(
                string.Format("The base type of the enum (\"{0}\") cannot be safely cast to \"{1}\".",
                              enumUnderlyingType.Name, indexerType)
                )
        {
        }
    }
    public class Caster<TKey, TValue>
    {
        private readonly Type baseEnumType;
        public Caster()
        {
            baseEnumType = typeof(TKey);
            if (!baseEnumType.IsEnum)
                throw new TypeNotSupportedException(baseEnumType);
        }
        public Caster(TValue[] data)
            : this()
        {
            Data = data;
        }
        public TValue this[TKey key]
        {
            get
            {
                var enumUnderlyingType = Enum.GetUnderlyingType(baseEnumType);
                var intType = typeof(int);
                if (!enumUnderlyingType.IsAssignableFrom(intType))
                    throw new CannotBeIndexerException(enumUnderlyingType, intType);
                var index = (int) Enum.Parse(baseEnumType, key.ToString());
                return Data[index];
            }
        }
        public TValue[] Data { get; set; }
        public static implicit operator TValue[](Caster<TKey, TValue> caster)
        {
            return caster.Data;
        }
        public static implicit operator Caster<TKey, TValue>(TValue[] data)
        {
            return new Caster<TKey, TValue>(data);
        }
    }
    // declaring and using it.
    Caster<DayOfWeek, string> messageArray =
        new[]
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday"
            };
    Console.WriteLine(messageArray[DayOfWeek.Sunday]);
    Console.WriteLine(messageArray[DayOfWeek.Monday]);
    Console.WriteLine(messageArray[DayOfWeek.Tuesday]);
    Console.WriteLine(messageArray[DayOfWeek.Wednesday]);
    Console.WriteLine(messageArray[DayOfWeek.Thursday]);
    Console.WriteLine(messageArray[DayOfWeek.Friday]);
    Console.WriteLine(messageArray[DayOfWeek.Saturday]);
