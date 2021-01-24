        public class ValueStorage
        {
            public int Value { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var _var1 = new ValueStorage() { Value = 0 };
                var _var2 = new ValueStorage() { Value = 1 };
                var _var3 = new ValueStorage() { Value = 2 };
    
                var varList = new List<ValueStorage> { _var1, _var2, _var3 };
                for (int i = 0; i < varList.Count; i++)
                {
                    varList[i].Value++;
                }
            }
        }
