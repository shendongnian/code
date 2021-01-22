    static void AssignVDirToAppPool(string metabasePath, string appPoolName)
    {
      //  metabasePath is of the form "IIS://<servername>/W3SVC/<siteID>/Root[/<vDir>]"
      //    for example "IIS://localhost/W3SVC/1/Root/MyVDir" 
      //  appPoolName is of the form "<name>", for example, "MyAppPool"
      Console.WriteLine("\nAssigning application {0} to the application pool named {1}:", metabasePath, appPoolName);
    
      try
      {
        DirectoryEntry vDir = new DirectoryEntry(metabasePath);
        string className = vDir.SchemaClassName.ToString();
        if (className.EndsWith("VirtualDir"))
        {
          object[] param = { 0, appPoolName, true };
          vDir.Invoke("AppCreate3", param);
          vDir.Properties["AppIsolated"][0] = "2";
          Console.WriteLine(" Done.");
        }
        else
          Console.WriteLine(" Failed in AssignVDirToAppPool; only virtual directories can be assigned to application pools");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Failed in AssignVDirToAppPool with the following exception: \n{0}", ex.Message);
      }
    }
