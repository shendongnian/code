    public class Program  {
    private const int SupervisorId = 0;
    static void Main(string[] args)
    {
      List<user> users = new List<user>();
      users.Add(new user {userId = 1, name = "1", supervisorId = SupervisorId});
      users.Add(new user { userId = 2, name = "2", supervisorId = SupervisorId});
      users.Add(new user { userId = 3, name = "3", supervisorId = 1 });
      users.Add(new user { userId = 4, name = "4", supervisorId = 1 });
      users.Add(new user { userId = 5, name = "5", supervisorId = 2 });
      users.Add(new user { userId = 6, name = "6", supervisorId = 5 });
      var nonSupervisors = users.Where(u => u.supervisorId != SupervisorId);
      Dictionary<user, user> userAndSupervisor = nonSupervisors.ToDictionary(user => user, user => FindSupervisor(users, user));
      Dictionary<user, List<user>> userAndHierarchy =nonSupervisors.ToDictionary(user => user, user => FindSupervisorHierarchy(users, user));
    }
    static user FindSupervisor(List<user> users, user user)
    {
      var parentUser = users.FirstOrDefault(u => u.userId == user.supervisorId);
      if (parentUser?.supervisorId != SupervisorId)
      {
        parentUser = FindSupervisor(users, parentUser);
      }
      return parentUser;
    }
    static List<user> FindSupervisorHierarchy(List<user> users, user user)
    {
      var parentUsers = users.Where(u => u.userId == user.supervisorId);
      if (parentUsers.All(x => x.supervisorId != SupervisorId))
      {
        parentUsers = parentUsers.Concat(FindSupervisorHierarchy(users, parentUsers.FirstOrDefault()));
      }
      return parentUsers.ToList();
    }
    }
