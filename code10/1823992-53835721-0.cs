    var entry = new DirectoryEntry{
			Path = "LDAP://yourDCname";
			Username = yourUsername;
			Password = yourPassword;
		};
		
		using(var searcher = new DirectorySearcher(entry))
		{
			searcher.Filter = "(sAMAccountName=Jane)";
			var result = searcher.FindOne();
			var user = result.GetDirectoryEntry();
			
			try
			{
				user.Invoke("ChangePassword", new object[] { oldPassword, newPassword});
                user.CommitChanges();
			}
			catch
			{
				throw;
			}
				
		}
