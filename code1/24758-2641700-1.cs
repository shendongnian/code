        public class MyClass
        {
            public string Name { get; set; }
        }
        public void Foo()
        {
            MyClass myObject = new MyClass();
            myObject.Name = "Dog";
            Bar(myObject);
            Console.WriteLine(myObject.Name); // Writes "Dog".
        }
        public void Bar(MyClass someObject)
        {
            MyClass myTempObject = new MyClass();
            myTempObject.Name = "Cat";
            someObject = myTempObject;
        }
