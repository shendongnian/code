    class ClientCode
    {
       public static void Main()
       {
             //create a list of person
             List<Person> personList = new List<Person>();
             Person p1 = new Person("John");
             Person p2 = new Person("Ram");
             personList.Add(p1);
             personList.Add(p2);
             // Someone can not add any other object then Person into personlist
             object q = new object();
             personList.Add(q); // Compile Error.
             // while accessing personlist, No NEED for TYPE Casting
             foreach(Person obj in personlist)
             {
                // do something, for person
             }
       }
    }
