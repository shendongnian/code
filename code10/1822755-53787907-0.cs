		public static void Seed(MyIdentityDbContext context)
		{
			HashSet<AspNetRole> roles = new HashSet<AspNetRole>();
			AspNetRole systemAdmin = new AspNetRole() { Id = "269E684F-9542-4F6A-8029-7516AA2ECD61", Name = "System Admin" };
			AspNetRole admin = new AspNetRole() { Id = "BE70FDF9-FCD5-4894-AE71-DA324A7D751E", Name = "Administrator" };
			AspNetRole normalUser = new AspNetRole() { Id = "D9C66DC0-190F-463A-88B0-8E1E4ED96BAF", Name = "User" };
			roles.Add(systemAdmin);
			roles.Add(admin);
			roles.Add(normalUser);
			foreach (AspNetRole role in roles)
			{
				AspNetRole dbrole = context.Roles.FirstOrDefault(r => r.Id == role.Id);
				if (dbrole != null)
				{
					dbrole.Name = role.Name;
					context.Roles.AddOrUpdate(dbrole);
				}
				else
				{
					context.Roles.Add(role);
				}			
			}
			context.SaveChanges();
		}
