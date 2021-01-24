    class WrapperObject<T> where T : SuperObject
    {
        private T _justATestField;
        public void Copy<TType>(WrapperObject<TType> wrapper) where TType : SuperObject
        {
            if (wrapper._justATestField is T tField)
            {
                _justATestField = tField;
            }
        }
        public WrapperObject<SuperObject> GetBaseWrapper()
        {
            var baseWrapper = new WrapperObject<SuperObject>();
            baseWrapper.Copy(this);
            return baseWrapper;
        }
    }
