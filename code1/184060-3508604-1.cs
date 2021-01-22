    protected void directoryInfo()
    {
      var di = new DirectoryInfo(Server.MapPath("/"));
      foreach (DirectoryInfo dir in di.GetDirectories())
      {
        Response.Write(dir.FullName + "<br/>");
        DirectorySecurity ds = dir.GetAccessControl(AccessControlSections.Access);
        foreach (FileSystemAccessRule fsar in ds.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
        {
          string userName = fsar.IdentityReference.Value;
          string userRights = fsar.FileSystemRights.ToString();
          string userAccessType = fsar.AccessControlType.ToString();
          string ruleSource = fsar.IsInherited ? "Inherited" : "Explicit";
          string rulePropagation = fsar.PropagationFlags.ToString();
          string ruleInheritance = fsar.InheritanceFlags.ToString();
          Response.Write(userName + " : " + userAccessType + " : " + userRights + " : " + ruleSource + " : " + rulePropagation + " : " + ruleInheritance + "<br/>");
        }
      }
    }
