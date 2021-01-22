    	public static SearchResult FindAccountByEmail(string email)
		{
			string filter = string.Format("(proxyaddresses=SMTP:{0})", email);
			using (DirectoryEntry gc = new DirectoryEntry("GC:"))
			{
				foreach (DirectoryEntry z in gc.Children)
				{
					using (DirectoryEntry root = z)
					{
						using (DirectorySearcher searcher = new DirectorySearcher(root, filter, new string[] { "proxyAddresses", "objectGuid", "displayName", "distinguishedName" }))
						{
							searcher.ReferralChasing = ReferralChasingOption.All;
							SearchResult result = searcher.FindOne();
							return result;
						}
					}
					break;
				}
			}
			return null;
		}
		static void Main(string[] args)
		{
			SearchResult result = FindAccountByEmail("someone@somewhere.com");
			string distinguishedName = result.Properties["distinguishedName"][0] as string;
			string name = result.Properties["displayName"] != null
			              	? result.Properties["displayName"][0] as string
			              	: string.Empty;
			Guid adGuid = new Guid((byte[]) (result.Properties["objectGUID"][0]));
			string emailAddress;
			var emailAddresses = (from string z in result.Properties["proxyAddresses"]
								  where z.StartsWith("SMTP")
								  select z);
			emailAddress = emailAddresses.Count() > 0 ? emailAddresses.First().Remove(0, 5) : string.Empty;
			Console.WriteLine(string.Format("{1}{0}\t{2}{0}\t{3}{0}\t{4}",
			              Environment.NewLine,
			              name,
			              distinguishedName,
			              adGuid,
			              emailAddress));
		}
