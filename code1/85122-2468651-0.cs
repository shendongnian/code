    using System;
    using System.DirectoryServices; 
    
    class MyClass1
    {
       static void Main()
       {
          try
          {
             String strPath = "IIS://localhost/W3SVC/1/Root";
             String strName = "";
    
             // Create a new 'DirectoryEntry' with the given path.
             DirectoryEntry myDE = new DirectoryEntry(strPath);
             DirectoryEntries myEntries = myDE.Children;
    
             // Create a new entry 'Sample' in the container.
             DirectoryEntry myDirectoryEntry = 
                myEntries.Add("Sample", myDE.SchemaClassName);
             // Save changes of entry in the 'Active Directory'.
             myDirectoryEntry.CommitChanges();
             Console.WriteLine (myDirectoryEntry.Name + 
                " entry is created in container.");
    
             // Find 'Sample' entry in container.
             myDirectoryEntry = myEntries.Find("Sample", myDE.SchemaClassName);
             Console.WriteLine(myDirectoryEntry.Name + " found in container.");
             // Remove 'Sample' entry from container.
             strName = myDirectoryEntry.Name;
             myEntries.Remove(myDirectoryEntry);
             Console.WriteLine(strName+ " entry is removed from container.");
    
          }
          catch(Exception e)
          {
             Console.WriteLine("The following exception was raised : {0}",
                e.Message);
          }
       }
    }
