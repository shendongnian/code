    public void FillTree(DataTable dtGroups, DataTable dtGroupsChilds)
    {
        treeViewGroups.Nodes.Clear();
        if (dtGroups == null) return;
        foreach (DataRow rowGroup in dtGroups.Rows)
        {
            parentNode = new TreeNode
            {
                Text = rowGroup["Groupname"].ToString(),
                Tag = rowGroup["Groupid"]
            };
            treeViewGroups.Invoke(new Add(AddParent), new object[] { parentNode });
    
            if (dtGroupsChilds == null) continue;
            foreach (DataRow rowUser in dtGroupsChilds.Rows)
            {
                if ((int)rowGroup["Groupid"] == (int)rowUser["Groupid"])
                {
                    TreeNode childNode = new TreeNode
                    {
                        Text = rowUser["Username"].ToString(),
                        Tag = rowUser["Phone"]
                    };
                    treeViewGroups.Invoke(new Add(AddChild), new object[] { childNode });
                    //System.Threading.Thread.Sleep(1000);
                }
            }
        }
        treeViewGroups.Update();
    }
