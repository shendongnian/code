    static void Main(string[] args)
    {
        Person p1 = new Person();
        p1.Name = "Name1";
        p1.arr = new int[5] {1,2,3,4,5 };
        Person p2 = (Person)p1.Clone();
        p1.Name = "Name2"; //Now p1.Name points to a new memory location
        //But p2.Name is still pointing to the location p1.Name had
        // originally pointed to.
        p1.arr[0] = 11; //here p1.arr and p2.arr are pointing to the same place
        //So since you are changing the value of one location it gets 
        //reflected in both
        Console.WriteLine(p2.Name); //Prints Name1
        Console.WriteLine(p2.arr[0].ToString()); //Prints 11
        Console.Read();
    }
