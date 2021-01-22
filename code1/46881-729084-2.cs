    class Holder
    {
        private object value;
        public Holder(object value)
        {
            this.value = value;
        }
        public static implicit operator Holder(DateTime dt)
        {
            return new Holder(dt);
        }
        public static implicit operator Holder(string s)
        {
            return new Holder(s);
        }
        // Implicit conversion operators from primitive types
    }
