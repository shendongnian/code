    private async void Form1_Load(object sender, EventArgs e)
    {
        var node = new Node() { Name = "1",
            Children = new List<Node> {
                new Node() { Name = "1-1",
                    Children = new List<Node> {
                        new Node() { Name = "1-1-1",
                            Children = new List<Node> {
                                new Node{ Name  = "1-1-1-1" }
                            }
                        }
                    }
                },
                new Node() { Name = "1-2",
                    Children = new List<Node> {
                        new Node(){ Name = "1-2-1"},
                        new Node(){ Name = "1-2-2"},
                    }
                },
            }
        };
        var treeNode = ConvertEntityToTreeNode(node, x => x.Children, x => new TreeNode(x.Name));
        treeView1.Nodes.Add(treeNode);
    }
