    public void CreateNewVirtualDirectory(int ServerId, string VirtualDirName, string Path, bool AccessScript){
          DirectoryEntry Parent = new DirectoryEntry(@"IIS://localhost/W3SVC/" + ServerId.ToString() + "/Root");
          DirectoryEntry NewVirtualDir;
          NewVirtualDir = Parent.Children.Add(VirtualDirName, "IIsWebVirtualDir");
          NewVirtualDir.Properties["Path"][0] = Path;
          NewVirtualDir.Properties["AccessScript"][0] = AccessScript;
          NewVirtualDir.CommitChanges();
    }
