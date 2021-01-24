    public class DeleteCommandBase<T> where T:ModelBase, INotifyPropertyChanged
    {
    
        public ViewModelBase<T> viewModel { get; set; }
    
        public DeleteCommandBase(ViewModelBase<T> vm)
        {
            viewModel = vm;
        }
        ...
    }
