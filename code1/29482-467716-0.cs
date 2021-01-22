    using(DirectoryEntry newUser = root.Children.Add("LDAPPATH"))
    {
          //Assign properties to the newUser
          newUser.CommitChanges();
          //write the new username to a file using a streamwriter.
    }
