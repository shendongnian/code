    class Person {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Address {get;set;}
    }
    using(var dc = new DataContext(connectionString)) {
        List<Person> people = dc.ExecuteQuery(@"
              SELECT Id, Name Address
              FROM [People]
              WHERE [Name] = {0}", name).ToList(); // some LINQ too
    }
 
