    public class Person
    {
              public int age;
              public string name;
              public Person(int age, string name)
              {
                       this.age = age;
                       this.name = name;
              }
    }
    // everyone under 25:
    List<person> young = people.FindAll(delegate(Person p) { return p.age < 25; });
    
    // sort your list: 
    people.Sort(delegate(Person p1, Person p2)
       { return p1.age.CompareTo(p2.age); });
