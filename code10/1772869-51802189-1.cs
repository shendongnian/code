    foreach (var Group in ItemsGroups) {
        TreeNode groupNode = treeView1.Nodes.Add(Group.Key.Group);
        foreach (var Category in Group) {
            TreeNode categoryNode = groupNode.Nodes.Add(Category.Key.Category);
            foreach (var Item in Category) {
                categoryNode.Nodes.Add(Item.item_name_original);
            }
        }
    }
