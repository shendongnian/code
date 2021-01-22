        static void CheckUserGroup(string userName, string userGroup)
        {
            var wi = new WindowsIdentity(userName);
            var wp = new WindowsPrincipal(wi);
            bool inRole = wp.IsInRole(userGroup);
            Console.WriteLine("User {0} {1} member of {2} AD group", userName, inRole ? "is" : "is not", userGroup);
        }
