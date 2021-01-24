     using System.Reflection;
     ...
     string filePath = Path.Combine(
        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), 
       "Items.csv"); 
