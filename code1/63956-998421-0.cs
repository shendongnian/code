            Customer c1 = new Customer();
            c1.FirstName.Value = "Me";
            Type t = c1.GetType();
            MemberInfo[] infos = t.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MemberInfo info in infos)
            {
                if (info.MemberType.ToString().Contains("Field"))
                {
                    Console.WriteLine("Found member {0} of type {1}", info.Name, info.MemberType);
                }
            }
