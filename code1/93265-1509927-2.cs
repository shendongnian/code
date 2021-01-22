        private bool TestProp<T>(T o, Action<T> f)
        {
            if (o == null)
                return false;
            
            f(o);
            return true;
        }
        public bool StoreIfKnown(object o)
        {
            return
                TestProp(o as A, x => A = x) ||
                TestProp(o as B, x => B = x) ||
                TestProp(o as C, x => C = x) ||
                false;
        }
