    bool valid = false;
    using (DirectoryEntry entry = new DirectoryEntry( results[0].Path, userId, password ))
    {
         try
         {
             if (entry.Guid != null)
             {
                valid = true;
             }
         }
         catch (NullReferenceException) {}
    }
