            //tree code
            //add husky list
            List<TreeNode> node8 = new List<TreeNode>();
            foreach (var item in huskyList)
            {
                node8.Add(new TreeNode(item.name));
            }
            TreeNode[] husky = node8.ToArray();
            //add chiwawa list
            List<TreeNode> node9 = new List<TreeNode>();
            foreach (var item in chiwawaList)
            {
                node9.Add(new TreeNode(item.name));
            }
            TreeNode[] chiwawa = node9.ToArray();
            //dog breed
            TreeNode node2 = new TreeNode("Husky", husky);
            TreeNode node3 = new TreeNode("Chiwawa", chiwawa);
            TreeNode[] dog = new TreeNode[] { node2, node3 };
            //dog parent
            TreeNode treeNode = new TreeNode("Dogs", dog);
            treeView1.Nodes.Add(treeNode);
            //add tabby list
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (var item in tabbyList)
            {
                nodes.Add(new TreeNode(item.name));
            }
            TreeNode[] tabby =nodes.ToArray();
            //add siamese list
            List<TreeNode> node7 = new List<TreeNode>();
            foreach (var item in siameseList)
            {
                node7.Add(new TreeNode(item.name));
            }
            TreeNode[] siamese = node7.ToArray();
            //cat breed
            TreeNode node4 = new TreeNode("Siamese", siamese);
            TreeNode node5 = new TreeNode("Tabby", tabby);
            TreeNode[] cat = new TreeNode[] { node4, node5 };
            //cat parent
            treeNode = new TreeNode("Cats", cat);
            treeView1.Nodes.Add(treeNode);
