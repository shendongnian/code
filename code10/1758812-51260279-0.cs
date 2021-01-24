    public static void Test()
    {
        var context = PrincipalContextProvider.ProvideContext();
        for (int i = 0; i < 10; i++)
        {
            using (var group = new GroupPrincipal(context, $"Hello_World_{i}"))
            {
                group.GroupScope = GroupScope.Universal;
                group.Save();
                ((DirectoryEntry)group.GetUnderlyingObject()).CommitChanges();
            }
            var _group = GetGroup($"CN=Hello_World_{i},CN=Users,DC=abc,DC=com");
            Console.WriteLine(_group.Name);
        }
    }
