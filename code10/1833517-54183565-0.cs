            var managerEmployees = new List<Employee>();
            for(int a = 0; a< selectManagersList.Count(); a++)
            {
                var found = await _context.Employees.FirstOrDefaultAsync(u=> u.UserName == managerUsers.ElementAt(a).UserName);
                if (found!=null)
                {
                    managerEmployees.Add(found);
                }
            }
