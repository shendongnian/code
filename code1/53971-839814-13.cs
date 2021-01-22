    public class SetOnce<T>
    {
        private readonly object syncLock = new object();
        private readonly bool throwIfNotSet;
        private readonly string valueName;
        private bool set;
        private T value;
        public SetOnce(string valueName)
        {
            this.valueName = valueName;
            throwIfGet = true;
        }
        public SetOnce(string valueName, T defaultValue)
        {
            this.valueName = valueName;
            value = defaultValue;
        }
        public T Value
        {
            get
            {
                lock (syncLock)
                {
                    if (!set && throwIfNotSet) throw new ValueNotSetException(valueName);
                    return value;
                }
            }
            set
            {
                lock (syncLock)
                {
                    if (set) throw new AlreadySetException(valueName, value);
                    set = true;
                    this.value = value;
                }
            }
        }
        public static implicit operator T(SetOnce<T> toConvert)
        {
            return toConvert.value;
        }
    }
    public class NamedValueException : InvalidOperationException
    {
        private readonly string valueName;
        public NamedValueException(string valueName, string messageFormat)
            : base(string.Format(messageFormat, valueName))
        {
            this.valueName = valueName;
        }
        public string ValueName
        {
            get { return valueName; }
        }
    }
    public class AlreadySetException : NamedValueException
    {
        private const string MESSAGE = "The value \"{0}\" has already been set.";
        public AlreadySetException(string valueName)
            : base(valueName, MESSAGE)
        {
        }
    }
    public class ValueNotSetException : NamedValueException
    {
        private const string MESSAGE = "The value \"{0}\" has not yet been set.";
        public ValueNotSetException(string valueName)
            : base(valueName, MESSAGE)
        {
        }
    }
