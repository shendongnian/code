    public class BaseClass { public string Name { get; set; } }
    
    public class FacadeBaseClasse : INotifyPropertyChanged //Facade that implements INPC interface
    {
        private readonly BaseClass baseC;
        public string Name
        {
            get => baseC.Name;
            set 
            {
                baseC.Name = value;
                OnPropertyChange();
            }
    }
