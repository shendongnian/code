    foreach (var g in query) {
        TreeNode groupNode = treeView1.Nodes.Add(g.Group);
        foreach (var fg in g.FetchaCategory) {
            TreeNode categoryNode = groupNode.Nodes.Add(fg.Category);
            foreach (var ng in fg.ItemsGroup) {
                categoryNode.Nodes.Add(ng.Item);
            }
        }
    }
