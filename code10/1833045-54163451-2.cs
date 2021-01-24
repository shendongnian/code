      static class Program
        {
            private class User
            {
                public string Name { get; set; }
                public string UserName { get; set; }
                public string Password { get; set; }
    
                public string PrepareForFile()
                {
                    return Name + "~" + UserName + "~" + Password + ",";
                }
            }
    
            static void Main(string[] args)
            {
                var users = File.ReadAllText(@"C:\users.txt").Split(',').ToList().Where(x=> !String.IsNullOrWhiteSpace(x));
    
                List<User> myUsers = new List<User>();
                foreach (var user in users)
                {
                    var information = user.Split('~');
                    User temp = new User();
                    temp.Name = information[0].Trim();
                    temp.UserName = information[1].Trim();
                    temp.Password = information[2].Trim();
                    myUsers.Add(temp);
                }
    
                var selectedUser = myUsers.Where(x => x.UserName == "username").SingleOrDefault();
                myUsers.Remove(selectedUser);
                selectedUser.Password = "Leo";
                myUsers.Add(selectedUser);
    
                List<string> formatForFile = new List<string>();
                foreach(var item in myUsers)
                {
                    formatForFile.Add(item.PrepareForFile());
                }
                File.WriteAllLines(@"C:\users.txt", formatForFile.ToArray());
            }
        }
