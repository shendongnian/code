    public static int Compare(Person p1, Person p2) =>
      let ages = Compare(p1.Age, p2.Age) in
        ages != 0 ? 
          ages : 
          let names = Compare(p1.Name, p2.Name) in
          names != 0 ? 
            names : 
            Compare(p1.Salary, p2.Salary);
