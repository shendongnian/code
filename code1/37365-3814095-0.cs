        public void TestMethod1()
        {
            Action<SomeClass, int> intInvoke = (o, data) => o.SomeMethod(data);
            Action<SomeClass, string> stringInvoke = (o, data) => o.SomeMethod(data);
            var list = new List<MyData> 
            {
                new MyData<int> { Data = 10, OnTypedInvoke = intInvoke },
                new MyData<string> { Data = "abc", OnTypedInvoke = stringInvoke }
            };
            var someClass = new SomeClass();
            foreach (var item in list)
            {
                item.OnInvoke(someClass);
            }
        }
        public abstract class MyData
        {
            public Action<SomeClass> OnInvoke;
        }
        public class MyData<T> : MyData
        {
            public T Data { get; set; }
            public Action<SomeClass, T> OnTypedInvoke 
            { set { OnInvoke = (o) => { value(o, Data); }; } }
        }
        public class SomeClass
        {
            public void SomeMethod(string data)
            {
                Console.WriteLine("string: {0}", data);
            }
            public void SomeMethod(int data)
            {
                Console.WriteLine("int: {0}", data);
            }
        }
