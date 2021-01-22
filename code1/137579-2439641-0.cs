    List<string> AddEntries(List<List<string>> entries) {
       List<string> finalEntries = new List<string>();
    
       if (entries != null && entries.Length > 0) {
          if (entries.Length > 1) {
             foreach(string entry in entries) {
                foreach(string subentry in AddEntries(entries.Skip(1)) {
                   finalEntries.Add(entry + subEntry);
                }
             }
          } else {
             foreach(string entry in entries[0]) { finalEntries.add(entry); }
          }
       }
       return finalEntries;
    }
