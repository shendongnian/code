    public class Person
    {
       public string Name { get; set; }
       public int Value { get; set; }
       public int Change { get; set; }
    
       public Person(string name, int value)
       {
          Name = name;
          Value = value;
          Change = 0;
       }
    }
    
    
    class Program
    {
       static void Main(string[] args)
       {
          List<Person> list1 = new List<Person>
                                  {
                                     new Person("a", 1),
                                     new Person("b", 2),
                                     new Person("c", 3),
                                     new Person("d", 4)
                                  };
          List<Person> list2 = new List<Person>
                                  {
                                     new Person("a", 4),
                                     new Person("b", 5),
                                     new Person("e", 6),
                                     new Person("f", 7)
                                  };
    
          List<Person> list3 = list2.ToList();
    
          foreach (var person in list1)
          {
             var existingPerson = list3.FirstOrDefault(x => x.Name == person.Name);
             if (existingPerson != null)
             {
                existingPerson.Change = existingPerson.Value - person.Value;
             }
             else
             {
                list3.Add(person);
             }
          }
    
          foreach (var person in list3)
          {
             Console.WriteLine("{0} {1} {2} ", person.Name,person.Value,person.Change);
          }
          Console.Read();
       }
    }
