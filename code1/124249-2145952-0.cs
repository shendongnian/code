    class Named
    {
        public string FullName
    }
    
    class Person: Named
    {
        public bool IsAlive
    }
    
    class Parent: Person
    {   
       public Collection<Child> Children
    }
    
    class Child : Person 
    {  
       public Parent parent;
    }
    
    public static void Main()
    {
      Named personAsNamed = new Person(); //upcast
      Person person = personAsNamed ; //downcast
      Child person = personAsNamed ; //failed downcast because object was instantiated
      //as a Person, and child is more specialized than(is a derived type of) Person
      //The Person has no implementation or data required to support the additional Child
      //operations. 
    }
