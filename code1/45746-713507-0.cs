    class Person 
    {
     string name;
     string lastname;
     public Person(string _name )  { this.name = _name; }
    }
    
    class ClientCode
    {
       public static void Main()
       {
             //create a list of person
             ArrayList personList = new ArrayList();
             Person p1 = new Person("John");
             Person p2 = new Person("Ram");
             personList.Add(p1);
             personList.Add(p2);
             // BUT, someone can do something like:
             // ArrayList does not stop adding another type of object into it
             object q = new object();
             personList.Add(q);
             // while accessing personlist
             foreach(object obj in personlist)
             {
                Person p = obj as Person;
                // do something, for person
                // But it will fail for last item in list 'q' since its is not person.
             }
       }
    }
