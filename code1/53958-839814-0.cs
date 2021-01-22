    public class SetOnce<T>
    {
        private bool set;
        private T value;
        public T Value
        {
            get { return value; }
            set
            {
                if (set) throw new AlreadySetException(value);
                this.value = value;
            }
        }
    }
