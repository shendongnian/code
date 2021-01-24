    public class BaseClass { public string Name { get; set; } }
    
    public class FacadeBaseClasse : INotifyPropertyChanged //Facade that implements INPC interface
    {
        private readonly BaseClass base;
        public string Name
        {
            get => base.Name;
            set 
            {
                base.Name = value;
                OnPropertyChange();
            }
    }
