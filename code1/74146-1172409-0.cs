    class Person {
       field Name;
       field LastName;
    }
    
    enum PersonAge {
       Child, Young, Retired
    }
    
    class Stage {
       public PersonAge Age { get; set; }
       field Salary;
    }
    
    class PersonStats {
       public Person Person { get; set; }
       public IList<Stage> Stages { get; set; }
    }
