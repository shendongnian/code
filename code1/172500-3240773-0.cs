        TeamFoundationServer tfs = new TeamFoundationServer("http://tfs:8080");
        VersionControlServer vcs = tfs.GetService<VersionControlServer>();
        Changeset cs = vcs.GetChangeset(6284868);
        foreach (Change change in cs.Changes)
        {
            if (change.Item.ServerItem.StartsWith("$/Application Common/Dev/src"))
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Changeset {0}, file {1}, changes {2}",
                    cs.ChangesetId, change.Item.ServerItem, change.ChangeType.ToString()));
            }
        }
