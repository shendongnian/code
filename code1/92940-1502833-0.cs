    using System;
    using System.Collections.Generic;
    using System.DirectoryServices;
    namespace ListADUsers.ConsoleApp
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Console.Clear();
    			IList<String> userList = new List<String>();
    			int badEntries = 0;
    			string domainName = String.Empty;
    			if (args.Length > 0)
    				domainName = args[0];
    			else
    			{
    				Console.Write("\nPlease enter your Active Directory domain name: ");
    				domainName = Console.ReadLine();
    			}
    			Console.Write(String.Format("\nAttempting to build user list for {0} ...\n\n", domainName));
    			try
    			{
    				if (!String.IsNullOrEmpty(domainName))
    				{
    					DirectoryEntry myDirectoryEntry = new DirectoryEntry(String.Format("LDAP://{0}", domainName));
    					DirectorySearcher mySearcher = new DirectorySearcher(myDirectoryEntry);
    					SortOption mySort = new SortOption("sn", SortDirection.Ascending);
    					mySearcher.Filter = ("(objectCategory=person)");
    					mySearcher.Sort = mySort;
    					foreach (SearchResult resEnt in mySearcher.FindAll())
    					{
    						try
    						{
    							if (!String.IsNullOrEmpty(resEnt.Properties["Mail"][0].ToString())
    								&& System.Text.RegularExpressions.Regex.IsMatch(resEnt.Properties["DisplayName"][0].ToString(), " |admin|test|service|system|[$]", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    								)
    								{
    									int space = resEnt.Properties["DisplayName"][0].ToString().IndexOf(" ");
    									string formattedName = String.Format("{0}{1}{2}",
    										resEnt.Properties["DisplayName"][0].ToString().Substring(space).PadRight(25),
    										resEnt.Properties["DisplayName"][0].ToString().Substring(0, space).PadRight(15),
    										resEnt.Properties["Mail"][0].ToString()
    										);
    									userList.Add(formattedName);
    								}
    						}
    						catch
    						{
    							badEntries++;
    						}
    					}
    					if (userList.Count > 0)
    					{
    						Console.WriteLine(String.Format("=========== Listing of users in the {0} domain\n", domainName));
    						Console.WriteLine(String.Format("{0}{1}{2}", "Surname".PadRight(25), "First Name".PadRight(15), "Email Address\n"));
    						for (int i = 0; i < userList.Count - 1; i++)
    							Console.WriteLine(userList[i].ToString());
    						Console.WriteLine(String.Format("\n=========== {0} users found in the {1} domain", userList.Count.ToString(), domainName));
    					}
    					else
    						Console.WriteLine(String.Format("\n=========== 0 users found in the {0} domain", userList.Count.ToString()));
    					Console.WriteLine(String.Format("=========== {0} objects could not be read", badEntries.ToString()));
    					Console.WriteLine("=========== End of Listing");
    				}
    				else
    				{
    					Console.WriteLine("Please enter a domain name next time!");
    				}
    			}
    			catch (Exception ex)
    			{
    				// in a production app you wouldn't show the user the exception details
    				Console.Write(String.Format("A critical error occurred.\nDetails: {0}", ex.Message.ToString()));
    			}
    		}
    	}
    }
