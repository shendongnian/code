       try {
          IWorkspaceFactory factories[] = { 
             new SdeFactory(), new FGDBFactory(), new AccessFactory() };
          IWorkspace workspace = factories
             .Single(wf=>wf.IsWorkspace(input)).Open(input);
          workspace.DoSoething();
       } catch(OperationException) {
          //can't remember the exact exception off the top of my head
          //Catch more than one match
       }
