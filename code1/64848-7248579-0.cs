    1    using System.DirectoryServices;
     2    using System;
     3    
     4    public class IISAdmin
     5    {
     6       public static int CreateWebsite(string webserver, string serverComment, string serverBindings, string homeDirectory)
     7       {
     8          DirectoryEntry w3svc = new DirectoryEntry("IIS://localhost/w3svc");
     9          
     10         //Create a website object array
     11         object[] newsite = new object[]{serverComment, new object[]{serverBindings}, homeDirectory};
     12         
     13         //invoke IIsWebService.CreateNewSite
     14         object websiteId = (object)w3svc.Invoke("CreateNewSite", newsite);
     15         
     16         return (int)websiteId;
     17      
     18      }
     19   
     20      public static void Main(string[] args)
     21      {
     22         int a = CreateWebsite("localhost", "Testing.com", ":80:Testing.com", "C:\\inetpub\\wwwroot");
     23         Console.WriteLine("Created website with ID: " + a);
     24      }
     25      
     26   }
