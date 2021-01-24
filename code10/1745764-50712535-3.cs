            // Code Using Linq
            TreeNode husky = new TreeNode("Husky", huskyList.Select(x => new TreeNode(x.name)).ToArray());
            TreeNode chiwawa = new TreeNode("Chiwawa", chiwawaList.Select(x => new TreeNode(x.name)).ToArray());
            TreeNode Siamese = new TreeNode("Siamese", siameseList.Select(x => new TreeNode(x.name)).ToArray());
            TreeNode Tabby = new TreeNode("Tabby", tabbyList.Select(x => new TreeNode(x.name)).ToArray());
            //parent nodes
            treeView1.Nodes.AddRange(new[] {
                new TreeNode("Dog", new TreeNode[] { husky, chiwawa }),
                new TreeNode("Cat", new TreeNode[] { Siamese, Tabby })
                });
 
