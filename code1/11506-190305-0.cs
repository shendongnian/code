    using System.DirectoryServices;
    using System;
     
    public class IISAdmin
    {
        /// <summary>
        /// Adds a host header value to a specified website. WARNING: NO ERROR CHECKING IS PERFORMED IN THIS EXAMPLE. 
        /// YOU ARE RESPONSIBLE FOR THAT EVERY ENTRY IS UNIQUE
        /// </summary>
        /// <param name="hostHeader">The host header. Must be in the form IP:Port:Hostname </param>
        /// <param name="websiteID">The ID of the website the host header should be added to </param>
        public static void AddHostHeader(string hostHeader, string websiteID)
        {
            
            DirectoryEntry site = new DirectoryEntry("IIS://localhost/w3svc/" + websiteID );
            try
            {                        
                //Get everything currently in the serverbindings propery. 
                PropertyValueCollection serverBindings = site.Properties["ServerBindings"];
                
                //Add the new binding
                serverBindings.Add(hostHeader);
                
                //Create an object array and copy the content to this array
                Object [] newList = new Object[serverBindings.Count];
                serverBindings.CopyTo(newList, 0);
                
                //Write to metabase
                site.Properties["ServerBindings"].Value = newList;            
                            
                //Commit the changes
                site.CommitChanges();
                            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
     
    public class TestApp
    {
        public static void Main(string[] args)
        {
            IISAdmin.AddHostHeader(":80:test.com", "1");
        }
    }
