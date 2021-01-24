    var workItemList = new List<WorkItemViewModel>();
    for (int i = 0; i < workItemCollection.Count; i++)
    {
       var workItem = workItemCollection[i];
       WorkItemViewModel model = null;
    
       switch (workItem.Type.Name)
       {
           case "Product Backlog Item":
               model = new WorkItemViewModel()
               {
                   // ...
               };
    
               workItemList.Add(model);
    
           case "Task":
               var task = new TFSTask()
               {
                   // ...
    
               };
    
               if (task.Storyid != 0)
               {
                   model.Tasks.Add(task);
               }
    
               break;
           case "Bug":
               var bug = new TFSIssue()
               {
                   // ...
               };
    
               if (bug.Storyid != 0)
               {
                   model.Issues.Add(bug);
               }
    
               break;
           default:
               break;
       }
    }
