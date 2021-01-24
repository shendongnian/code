    public class Group
    {
        public static Dictionary<int, Group> groups = new Dictionary<int, Group>();
        // Members, user and groups
        public List<string> Users = new List<string>();
        public List<int> GroupIds = new List<int>();
        public IEnumerable<string> AggregateUsers()
        {
            IEnumerable<string> aggregatedUsers = Users.AsEnumerable();
            foreach (int id in GroupIds)
                aggregatedUsers = aggregatedUsers.Concat(groups[id].AggregateUsers());
            return aggregatedUsers;
        }
        public IEnumerable<string> AggregateUsers(List<IEnumerable<string>> aggregatedUsers = null)
        {
            bool topStack = false;
            if (aggregatedUsers == null)
            {
                topStack = true;
                aggregatedUsers = new List<IEnumerable<string>>();
            }
            aggregatedUsers.Add(Users.AsEnumerable());
            foreach (int id in GroupIds)
                groups[id].AggregateUsers(aggregatedUsers);
            if (topStack)
                return aggregatedUsers.SelectMany(i => i);
            else
                return null;
        }
    }
    static void Main(string[] args)
    {
        for (int i = 0; i < 1000; i++)
            Group.groups.TryAdd(i, new Group());
        for (int i = 0; i < 999; i++)
            Group.groups[i + 1].GroupIds.Add(i);
        for (int i = 0; i < 10000; i++)
            Group.groups[i / 10].Users.Add($"user{i}");
        Stopwatch stopwatch = Stopwatch.StartNew();
        IEnumerable<string> users = Group.groups[999].AggregateUsers();
        Console.WriteLine($"Aggregation via nested concatenation took {stopwatch.ElapsedMilliseconds} ms");
        stopwatch = Stopwatch.StartNew();
        bool contains = users.Contains("user0");
        Console.WriteLine($"Search through IEnumerable from nested concatenation was {contains} and took {stopwatch.ElapsedMilliseconds} ms");
        stopwatch = Stopwatch.StartNew();
        users = Group.groups[999].AggregateUsers(null);
        Console.WriteLine($"Aggregation via SelectMany took {stopwatch.ElapsedMilliseconds} ms");
        stopwatch = Stopwatch.StartNew();
        contains = users.Contains("user0");
        Console.WriteLine($"Search through IEnumerable from SelectMany was {contains} and took {stopwatch.ElapsedMilliseconds} ms");
        stopwatch = Stopwatch.StartNew();
        users = Enumerable.Empty<string>();
        foreach (Group group in Group.groups.Values.Reverse())
            users = users.Concat(group.Users);
        Console.WriteLine($"Aggregation via flat concatenation took {stopwatch.ElapsedMilliseconds} ms");
        stopwatch = Stopwatch.StartNew();
        contains = users.Contains("user0");
        Console.WriteLine($"Search through IEnumerable from flat concatenation was {contains} and took {stopwatch.ElapsedMilliseconds} ms");
        Console.Read();
    }
