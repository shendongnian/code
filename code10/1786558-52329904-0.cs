    static void Main(string[] args)
    {
        Group group1 = new Group("Group1");
        Group group2 = new Group("Group2");
        Group group3 = new Group("Group3");
        List<User> users = new List<User>(new User[] {
            new User() { Username = "User1", Groups = new List<Group>(new Group[] { group1,group2})  },
            new User() { Username = "User2", Groups = new List<Group>(new Group[] { group1,group3})  },
            new User() { Username = "User3", Groups = new List<Group>(new Group[] { group2,group3})  }
        });
        var result1 = from user in users
                     from grp in user.Groups
                     group user by grp into pivot
                     select pivot;
        foreach (var r in result1)
        {
            Console.WriteLine(r.Key.Name);
            foreach (var u in r)
                Console.WriteLine(u.Username);
        }
        Console.WriteLine();
        var result = users.SelectMany(user => user.Groups.Select(group => (user, group))
                  .GroupBy(item => item.group,item=>item.user));
        foreach (var r in result)
        {
            Console.WriteLine(r.Key.Name);
            foreach (var u in r)
                Console.WriteLine(u.Username);
        }
        Console.ReadKey();
    }
    public class Group : IEquatable<Group>
    {
        public Group(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public bool Equals(Group other)
        {
            return other.Name == Name;
        }
        public override bool Equals(object obj)
        {
            return ((Group)obj).Name==Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
    public class User
    {
        public string Username { get; set; }
        public List<Group> Groups { get; set; }
    }
