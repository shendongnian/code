    public class Node: System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public string Label
        {
            get { return this._Label; }
            set
            {
                this._Label = value;
                this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Label"));
            }
        }
        private string _Label;
        protected virtual void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs propertyChangedEventArgs)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, propertyChangedEventArgs);
        }
    }
