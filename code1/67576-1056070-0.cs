     foreach (SearchResult result in results)
     {
       string dept = String.Empty;
       DirectoryEntry de = result.GetDirectoryEntry();
       if (de.Properties.Contains("department"))
       {
         dept = de.Properties["department"][0].ToString();
         if (!dict.ContainsKey(dept))
         {
           dict.Add(result.Properties["department"][0].ToString();
         }
      }
    }
