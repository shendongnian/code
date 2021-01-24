    class Person
    {
        public string name;
        public float score;
        public int age;
    }
    
    Person ptr1 = new Person { name="Elena", score= 10, age= 20 };
    ptr2 = ptr1;
    ptr2.name="Miguel";
    Console.WriteLine("Value: " + ptr1.name); // prints Miguel
