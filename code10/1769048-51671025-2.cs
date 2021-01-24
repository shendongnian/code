    private string GetParentPath(string path)
    {
        string modifyingPath = path;
        BranchObject branchObject = versionControlServer.QueryBranchObjects(new ItemIdentifier(modifyingPath), RecursionType.None).FirstOrDefault();
        while (branchObject == null && !string.IsNullOrWhiteSpace(modifyingPath))
        {
            modifyingPath = modifyingPath.Substring(0, modifyingPath.LastIndexOf("/"));
            branchObject = versionControlServer.QueryBranchObjects(new ItemIdentifier(modifyingPath), RecursionType.None).FirstOrDefault();
        }
        string root = branchObject?.Properties?.ParentBranch?.Item;
        return root == null ? null : $"{root}{path.Replace(modifyingPath, "")}";
    }
