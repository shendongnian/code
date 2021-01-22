    public class TestEquals
    {
        private int _x;
        public TestEquals(int x)
        {
            this._x = x;
        }
    
        public override bool Equals(object obj)
        {
            TestEquals te = (TestEquals)obj;
            if (te == null) return false;
    
            foreach (var field in typeof(TestEquals)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (!field.GetValue(this).Equals(field.GetValue(te)))
                    return false;
            }
            return true;
        }
    }
