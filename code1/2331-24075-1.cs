    public string GroupMembers(string targethost, string groupname, string targetusername, string targetpassword)
    		{
    			StringBuilder result = new StringBuilder(); 
    			try
    			{
    				ConnectionOptions Conn = new ConnectionOptions();
    				if (targethost != Environment.MachineName) //WMI errors if creds given for localhost
    				{
    					Conn.Username = targetusername; //can be null
    					Conn.Password = targetpassword; //can be null
    				}
    				Conn.Timeout = TimeSpan.FromSeconds(2);
    				ManagementScope scope = new ManagementScope("\\\\" + targethost + "\\root\\cimv2", Conn);
    				scope.Connect();
    				StringBuilder qs = new StringBuilder();
    				qs.Append("SELECT PartComponent FROM Win32_GroupUser WHERE GroupComponent = \"Win32_Group.Domain='");
    				qs.Append(targethost);
    				qs.Append("',Name='");
    				qs.Append(groupname);
    				qs.AppendLine("'\"");
    				ObjectQuery query = new ObjectQuery(qs.ToString());
    				ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    				ManagementObjectCollection queryCollection = searcher.Get();
    				foreach (ManagementObject m in queryCollection)
    				{
    					ManagementPath path = new ManagementPath(m["PartComponent"].ToString());                                        
    					{ 
    						String[] names = path.RelativePath.Split(',');
    						result.Append(names[0].Substring(names[0].IndexOf("=") + 1).Replace("\"", " ").Trim() + "\\"); 
    						result.AppendLine(names[1].Substring(names[1].IndexOf("=") + 1).Replace("\"", " ").Trim());                    
    					}
    				}
    				return result.ToString();
    			}
    			catch (Exception e)
    			{
    				Console.WriteLine("Error. Message: " + e.Message);
    				return "fail";
    			}
    		}
