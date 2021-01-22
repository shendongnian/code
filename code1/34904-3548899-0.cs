    ClearCase.Application cc = new ClearCase.Application();
    ClearCase.CCView view = cc.get_View("YOUR VIEW");
    ClearCase.CCActivity activity = view.CurrentActivity;
    ClearCase.CCVersions versions = activity.get_ChangeSet(view);
    
    int nVersion = -1;
    foreach (ClearCase.CCVersion version in versions)
    {
          if (version.Path.Contains("YOUR FILENAME"))
          {
               nVersion = version.VersionNumber;
               ClearCase.CCBranch branch = version.Branch;
          }
    }
