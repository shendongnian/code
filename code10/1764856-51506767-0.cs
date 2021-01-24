    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public object dynamicField {get; set;}
    }
    List<User> users = new List<User>();
    users.Add(new User { FirstName = "Foo", LastName = "Bar"} );
    users.Add(new User { FirstName = "Bar", LastName = "Foo"} );
    foreach (var obj in users)
    {
      obj.dynamicField = obj.FirstName + " " + obj.LastName;
    }
