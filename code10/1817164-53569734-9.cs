    namespace ViewModels.Base
    {
        public class ViewModelBase : ReactiveObject
        {
            public virtual Task InitializeAsync(object parameter)
            {
                return Task.CompletedTask;
            }
        }
    }
    
