     protected void Page_Load(object sender, EventArgs e)
            {
                var hierarchicalData = new CategoryRepository().GethierarchicalTree();
                tv1.Nodes.Clear();
                var root = new TreeNode("0","Root");
                tv1.Nodes.Add(root);
                BindTreeRecursive(hierarchicalData, root);
            }
    
            private void BindTreeRecursive(List<Category> hierarchicalData, TreeNode node)
            {
                foreach (Category category in hierarchicalData)
                {
                    if (category.Children.Any())
                    {
                        var n = new TreeNode(category.Name, category.Id.ToString());
                        node.ChildNodes.Add(n);
                        BindTreeRecursive(category.Children.ToList(), n);
                    }
                    else
                    {
                        var n = new TreeNode(category.Name, category.Id.ToString());
                        node.ChildNodes.Add(n);
                           
                        if (new ProductRepository().Get(a => a.ProductCategoryId == category.Id).Any())
                        {
                            var catRelatedProducts = new ProductRepository().Get(a => a.ProductCategoryId == category.Id).ToList();
    
                            foreach (Product product in catRelatedProducts)
                            {
                                n.ChildNodes.Add(new TreeNode(product.Name,product.Id.ToString()));
                            }
                        }
                    }
                }
            }
