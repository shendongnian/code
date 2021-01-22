    public class MyDictionary : Dictionary<int, MyValue>
    {
        public void Add(int key, object value1, double value2)
        {
            MyValue val;
            val.Value1 = value1;
            val.Value2 = value2;
            this.Add(key, val);
        }
    }
