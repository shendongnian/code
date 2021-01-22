    using System.DirectoryServices;
    using System;
    
    public class IISAdmin
    {
       public static void GetWebsiteID(string websiteName)
       {
          DirectoryEntry w3svc = new DirectoryEntry("IIS://localhost/w3svc");
          
         foreach(DirectoryEntry de in w3svc.Children)
         {
            if(de.SchemaClassName == "IIsWebServer" && de.Properties["ServerComment"][0].ToString() == websiteName)
            {
               Console.Write(de.Name);
            }
         
         }
      
      }
      public static void Main()
      {
         GetWebsiteID("Default Web Site");
      }
   
