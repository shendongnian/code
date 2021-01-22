    public class SetOnce<T>
    {
        private readonly object syncLock = new object();
        private readonly bool throwIfGet;
        private bool set;
        private T value;
        public SetOnce()
        {
            throwIfGet = true;
        }
        public SetOnce(T defaultValue)
        {
            value = defaultValue;
        }
        public T Value
        {
            get
            {
                lock (syncLock)
                {
                    if (!set && throwIfGet) throw new ValueNotSetException();
                    return value;
                }
            }
            set
            {
                lock (syncLock)
                {
                    if (set) throw new AlreadySetException(value);
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
