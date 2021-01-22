    public abstract class ViewModelBase<TModel>
    {
        private readonly TModel _dataObject;
    
        public CustomObjectViewModel(TModel dataObject)
        {
            _dataObject = dataObject;
        }
    
        protected TModel DataObject { get; }
    }
    
    public class CustomObjectViewModel : ViewModelBase<CustomObject>
    {
        public string Title
        {
            // implementation excluded for brevity
        }
    }
    
    public class CustomItemViewModel : ViewModelBase<CustomItem>
    {
        public string Title
        {
            // implementation excluded for brevity
        }
    
        public string Description
        {
            // implementation excluded for brevity
        }
    }
