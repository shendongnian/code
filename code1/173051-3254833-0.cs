    public class DeletableObject
    {
        public ICommand DeleteCommand { get; }
    
        public DeleteableObject()
        {
            DeleteCommand = new DeleteCommand(this);
        }
    }
    
    public class DeleteCommand : ICommand
    {
        private DeletableObject _DeletableObject;
    
        public DeleteCommand(DeletableObject deletableObject)
        {
            _DeletableObject = deletableObject;
        }
    
        // skipped the implementation of ICommand but it deletes _DeletableObject
    }
