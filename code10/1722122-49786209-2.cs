            foreach (var user in principalSearcher.FindAll())
            {
                var userDe = (DirectoryEntry) user.GetUnderlyingObject();
                users.Add(new ADUser
                {
                    SamAccountName = user.SamAccountName,
                    DisplayName = user.DisplayName,
                    Title = userDe.Properties["title"]?.Value.ToString()
                });
            }
