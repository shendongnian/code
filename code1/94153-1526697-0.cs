    public partial class Product : INotifyPropertyChanged {
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        partial void OnProductIDChanged() { FirePropertyChanged("ProductID"); }
        partial void OnProductNameChanged() { FirePropertyChanged("ProductName"); }
        
        private void FirePropertyChanged(string property) { ... }
    }
