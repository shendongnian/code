    public static void SearchAndSaveSelectedNodes(TreeNodeCollection nodes)
	{
	    // open config (only once)
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		
		// make edits (recursive)
		SearchAndSaveSelectedNodesRecursive(nodes, config);
		
		// save (only once)
		config.Save(ConfigurationSaveMode.Modified);
        // (afaik there is no need to refresh the section)
	}
	
    private static void SearchAndSaveSelectedNodesRecursive(TreeNodeCollection nodes, Configuration config)
    {
        foreach (TreeNode n in nodes)
        {
    	    config.AppSettings.Settings.Remove(n.Name);
            if (n.Checked)
            {
                // no need to delete again here (it's already deleted)
    		    config.AppSettings.Settings.Add(n.Name, n.Name + "@" + n.FullPath);
            }
            SearchAndSaveSelectedNodesRecursive(n.Nodes, config);
        }
    }
