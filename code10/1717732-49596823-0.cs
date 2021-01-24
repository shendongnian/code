    public void GetProjectInfo(string projectname, string Iteration)
    {
        var query =
                $@"SELECT 
                     [System.Id], [System.Title],[Story.Author],[Story.Owner],[System.AssignedTo],
                     [System.WorkItemType],[Microsoft.VSTS.Scheduling.StoryPoints],[Microsoft.VSTS.Common.Priority],
                     [Microsoft.VSTS.Scheduling.Effort], [Actual.Effort.Completed], [System.State], [System.IterationPath] 
                 FROM WorkItemLinks 
                 WHERE ([Source].[System.TeamProject]='{projectname}' 
                       AND [Source].[System.WorkitemType] IN ('Feature', 'Bug', 'Product Backlog Item', 'Task') 
                       ${(string.IsNullOrEmpty(Iteration) ? "" : $"AND [Source].[System.IterationPath] IN ('{Iteration}'))") }
                       AND ([System.Links.LinkType]='System.LinkTypes.Hierarchy-Forward')
                ORDER BY [System.Id] mode (Recursive)";
    }
