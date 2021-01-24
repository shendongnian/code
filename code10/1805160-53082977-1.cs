    private async Task<List<TreeNode>> GetBlobDirectoriesAsync(CloudBlobContainer container, TreeNode parentNode)
            {
                var directory = container.GetDirectoryReference(parentNode.Key);
                var folders = await directory.ListBlobsSegmentedAsync(null);
                var tree = new List<TreeNode>();
                if (folders.Results.Any())
                    parentNode.HasChildren = true;
                foreach (var folder in folders.Results.ToList())
                {
                    if (folder is CloudBlobDirectory directoryItem)
                    {
                        tree.Add(new TreeNode
                        {
                            Id = 0,
                            Type = TreeNodeType.Folder,
                            Key = directoryItem.Prefix,
                            Name = directoryItem.Prefix.Replace(directoryItem.Parent.Prefix, "").TrimEnd('/'),
                            Url = directoryItem.Uri.ToString()
                        });
                    }
                    if (folder is CloudPageBlob pageItem)
                    {
                        tree.Add(new TreeNode
                        {
                            Id = 0,
                            Key = pageItem.Name,
                            Name = pageItem.Name,
                            Url = pageItem.Uri.ToString()
                        });
                    }
                    if (folder is CloudBlockBlob blockItem)
                    {
                        tree.Add(new TreeNode
                        {
                            Id = 0,
                            Type = TreeNodeType.File,
                            Key = blockItem.Name.Replace(blockItem.Parent.Prefix,""),
                            Name = blockItem.Name.Replace(blockItem.Parent.Prefix, ""),
                            Url = blockItem.Uri.ToString()
                        });
                    }
                }
    
                foreach (var treeNode in tree)
                {
                    if(treeNode.Type == TreeNodeType.Folder)
                        treeNode.Children = await GetBlobDirectoriesAsync(container, treeNode);
                }
                return tree;
            }
