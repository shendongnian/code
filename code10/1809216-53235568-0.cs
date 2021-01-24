    public List<string> GetWorkItemSourceCodeLinks(int bugId)
    {
        var workItemSourceCodeLinks = new List<string>();         
        lock (_witLock)
        {
            var workItem = _witClient.GetWorkItemAsync(bugId, null, null, WorkItemExpand.Relations).Result;
            if (workItem?.Relations != null)
            {
                var validSourceCodeLinkTypes = new List<string> { "ArtifactLink", "Hyperlink" };
                foreach (var relation in workItem.Relations)
                {
                    if (validSourceCodeLinkTypes.Contains(relation.Rel))
                    {
                        workItemSourceCodeLinks.Add(relation.Url);
                    }
                }
            }
        }
    }  
