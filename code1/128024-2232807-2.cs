    int total;
    foreach (MembershipUser user in Provider.Membership.GetAllUsers(0, 10, out total))
    {
        var sb = new StringBuilder();
        sb.AppendLine(user.UserName);
        foreach (var role in Provider.Role.GetRolesForUser(user.UserName))
        {
            sb.AppendLine("\t" + role);
        }
    
        Console.WriteLine(sb.ToString());
    }
