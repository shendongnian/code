    public interface ISharedContext 
    {
        string Name { get; set; }
    }
    
    public class SharedContext : MvxNotifyPropertyChanged, ISharedContext 
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
