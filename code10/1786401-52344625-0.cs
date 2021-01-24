    public class WorkspaceItemViewModelFactory
    {
        private readonly IWorkspaceManager _workspaceManager;
        
        public WorkspaceItemViewModelFactory(IWorkspaceManager workspaceManager)
        {
            _workspaceManager = workspaceManager;
        }
        
        public WorkspaceItemViewModel CreateWorkspaceItem()
        {
            return new WorkspaceItemViewModel(_workspaceManager);
        }
    }
