    /// <summary>
    /// Finds the users in the given group. Eg groupName=My-Group-Name-Blah
    /// returns an array of users eg: DOMAIN\user
    /// </summary>
    string[] UsersInGroup(string groupName)
    {
      List<String> users = new List<string>();
      // First, find the group:
      string query = string.Format("(CN={0})", groupName);
      SearchResult searchResult = new DirectorySearcher(query).FindOne();
      DirectoryEntry group = new DirectoryEntry(searchResult.Path);
      // Find all the members
      foreach (object rawMember in (IEnumerable)group.Invoke("members"))
      {
        // Grab this member's SID
        DirectoryEntry member = new DirectoryEntry(rawMember);
        byte[] sid = null;
        foreach (object o in member.Properties["objectSid"]) sid = o as byte[];
        // Convert it to a domain\user string
        try
        {
          users.Add(
            new SecurityIdentifier(sid, 0).Translate(typeof(NTAccount)).ToString());
        }
        catch { } // Some SIDs cannot be discovered - ignore these
      }
      return users.ToArray();
    }
