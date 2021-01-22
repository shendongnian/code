        public static void Foo()
        {
            MyClass myObject = new MyClass();
            myObject.Name = "Dog";
            Bar(myObject);
            Console.WriteLine(myObject.Name); // Writes "Dog". 
            Bar(ref myObject);
            Console.WriteLine(myObject.Name); // Writes "Cat". 
        }
        public static void Bar(MyClass someObject)
        {
            MyClass myTempObject = new MyClass();
            myTempObject.Name = "Cat";
            someObject = myTempObject;
        }
        public static void Bar(ref MyClass someObject)
        {
            MyClass myTempObject = new MyClass();
            myTempObject.Name = "Cat";
            someObject = myTempObject;
        }
