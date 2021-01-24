    using System.DirectoryServices.Protocols;
	public class UserInfo
	{
		public string SAMAccountName;
		public string DomainHostName;
		public string ADSDirectory;
		public Dictionary<string, string> UserAttributes;
		// Some attributes not really strings and require extra handling - but simplied for example
		// This is really just for illustrative purposes
		public UserInfo(string a_SAMAccountName, string a_DomainHostName = "ldap.mydomain:3268", string a_ADSDirectory = "ours.net")
		{
			UserAttributes = new Dictionary<string, string>();
			SAMAccountName = a_SAMAccountName;
			DomainHostName = a_DomainHostName;
			a_ADSDirectory = a_ADSDirectory;
		}
	}
	public static class GetUserAttributes
	{
		public static List<string> WantedAttributes;
		static GetUserAttributes()
		{
			WantedAttributes = new List<string>();
			WantedAttributes.Add("mail");
			//... Add Properties Wanted
		}
		public static void GetUserAttributes(UserInfo a_user)
		{
			using (HostingEnvironment.Impersonate())
			{
				LdapDirectoryIdentifier z_entry = new LdapDirectoryIdentifier(a_user.DomainHostName, true, false);
				using (LdapConnection z_remote = new LdapConnection(z_entry))
				{
					z_remote.SessionOptions.VerifyServerCertificate = delegate (LdapConnection l, X509Certificate c) { return true; };
					z_remote.SessionOptions.ReferralChasing = ReferralChasingOptions.None;
					z_remote.SessionOptions.ProtocolVersion = 3;
					z_remote.Bind();
					SearchRequest z_search = new SearchRequest();
					z_search.Scope = System.DirectoryServices.Protocols.SearchScope.Subtree;
					z_search.Filter = "(SAMAccountName=" + a_user.SAMAccountName + ")";
					z_search.DistinguishedName = a_user.ADSdirectory;
					foreach (List<string> z_item in WantedAttributes)
					{
						z_search.Attributes.Add(z_item);
					}
					SearchResponse z_response = (SearchResponse)z_remote.SendRequest(z_search);
					if (z_response != null)
					{
						foreach (SearchResultEntry z_result in z_response.Entries)
						{
							foreach (string z_property in z_result.Attributes.AttributeNames)
							{
								if (WantedAttributes.ContainsKey(z_property))
								{
									DirectoryAttribute z_details = a_result.Attributes[z_property];
									if (z_details.Count == 1)
									{
										// Special handling required for Attributes that aren't strings objectSid, objectGUID, etc
										string z_value = z_details[0].ToString().Trim();
										if (!string.IsNullOrWhiteSpace(z_value))
										{
											a_user.UserAttributes.Add(z_property, z_value);
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
