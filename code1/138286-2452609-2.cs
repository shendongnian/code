    public class IdGenerator
    {
        private const int Min = 0xA0000;
        private const int Max = 0xFFFF9;
        private int _value = Min - 1;
        public string NextId()
        {
            if (_value < Max)
            {
                _value++;
            }
            else
            {
                _value = Min;
            }
            return _value.ToString("X");
        }
    }
