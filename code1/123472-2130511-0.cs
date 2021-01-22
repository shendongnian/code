    TreeNode result;
    try {
        string[] subdirs = Directory.GetDirectories(path);
        result = new TreeNode(path);
        foreach(string subdir in subdirs) {
            TreeNode child = TraverseDirectory(subdir);
            if(child != null) { result.Nodes.Add(child); }
        }
        return result;
    } catch (FindTheSpecificException) {
        // ignore dir
        result = null;
    }
    return result;
