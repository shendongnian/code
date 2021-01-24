    static void Main(string[] args)
    {
       var list1 = new List<Person>();
       var list2 = new List<Person>();
       list1.Add(new Person(1, "james", "moon"));
       list1.Add(new Person(1, "bob", "bar"));
       list1.Add(new Person(1, "tim", "lane"));
       list1.Add(new Person(1, "fizz", "sea"));
       list2.Add(new Person(1, "buzz", "space"));
       list2.Add(new Person(1, "james", "moon"));
       var result = findDuplicates(list1, list2);
    }
    public static List<Person> findDuplicates(List<Person> l1, List<Person> l2)
    {
       return l1.Where(p => l2.Any(z => z.FName == p.FName && z.Addre == p.Addre)).ToList();
    }
