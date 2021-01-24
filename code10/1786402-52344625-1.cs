    public class ExampleViewModel : ViewModelBase
    {
        public ExampleViewModel(IWorkspaceItemViewModelFactory workspaceItemViewModelFactory)
        {
            AddItemCommand = new ActionCommand(() =>
            {
                var newItem = workspaceItemViewModelFactory.CreateWorkspaceItem();
                WorkspaceItems.Add(newItem);
            });
        }
        public ICommand AddItemCommand { get; }
        public ObservableCollection<WorkspaceItemViewModel> WorkspaceItems { get; } = new ObservableCollection<WorkspaceItemViewModel>();
    }
