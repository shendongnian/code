     using System.Reflection;
     ...
     string filePath = Path.Combine(
        Path.GetDirectory(Assembly.GetEntryAssembly().Location), 
       "Items.csv"); 
