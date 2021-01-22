    public class TestA
    {
        public int MyProperty { get; set; }
    }
    public class TestB
    {
        public int MyProperty { get; set; }
    }
                HashMapDictionary<TestA, TestB> hashMapDictionary = new HashMapDictionary<TestA, TestB>();
                var a = new TestA() { MyProperty = 9999 };
                var b = new TestB() { MyProperty = 60 };
                var b2 = new TestB() { MyProperty = 5 };
                hashMapDictionary.Add(a, b);
                hashMapDictionary.Add(a, b2);
                hashMapDictionary.TryGetValues(a, out List<TestB> result);
                foreach (var item in result)
                {
                    //do something
                }
