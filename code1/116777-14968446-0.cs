    using (var c = SequentialDataCache<TreeNode>.Initialize(deleteOnClose: false))
            {
                //add items to collection
                for (int i = 0; i < 1000; i++)
                {
                    var treeNode = new TreeNode()
                                       {
                                           Word = string.Format("Word{0}", i),
                                           Children = new Dictionary<string, TreeNode>()
                                       };
                    for (int j = 0; j < 100; j++)
                    {
                        var child = new TreeNode() { Word = string.Format("Word{0}", j) };
                        treeNode.Children.Add(string.Format("key{0}{1}", i, j), child);
                    }
                    c.Add(treeNode);
                }
                //assert query
                Assert.AreEqual("Word0", c[0].Word);
                Assert.AreEqual("Word1", c[0].Children["key01"].Word);
                Assert.AreEqual("Word100", c[100].Word);
            }
