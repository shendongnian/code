     public async Task<ActionResult> List()
            {
                CloudBlobContainer container = GetCloudBlobContainer();
                List<string> blobs = new List<string>();
                BlobResultSegment resultSegment = container.ListBlobsSegmentedAsync(null).Result;
                var tree = new List<TreeNode>();
                int i = 1;
                foreach (IListBlobItem item in resultSegment.Results)
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob) item;
                        blobs.Add(blob.Name);
                    }
                    else if (item.GetType() == typeof(CloudPageBlob))
                    {
                        CloudPageBlob blob = (CloudPageBlob) item;
                        blobs.Add(blob.Name);
                    }
                    else if (item.GetType() == typeof(CloudBlobDirectory))
                    {
                        CloudBlobDirectory dir = (CloudBlobDirectory) item;
                        tree.Add(new TreeNode
                        {
                            Id = i,
                            Type = TreeNodeType.Folder,
                            Key = dir.Prefix,
                            Name = dir.Prefix.TrimEnd('/'),
                            Url = dir.Uri.ToString()
                        });
                        i++;
                    }
                }
    
                foreach (var treeNode in tree)
                {
                    if (treeNode.Type == TreeNodeType.Folder)
                        treeNode.Children = await GetBlobDirectoriesAsync(container, treeNode);
                }
                return View(tree);
            }
