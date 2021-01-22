    public class A
    {
        var count = 0;
        private int? _prop = null;
        public int? Prop
        {
            get 
            {
                ++count;
                return _prop
            }
            set
            {
                _prop = value;
            }
        }
    }
