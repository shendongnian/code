    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(String PropName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
            }
        }
    
        protected void SetAndRaisePropertyChanged<T>(ref T Prop, T value, [CallerMemberName] String PropName = "")
        {
            Prop = value;
            RaisePropertyChanged(PropName);
        }
    }
    
    public class CustomCollection<T> : ObservableCollection<T> where T : ModelBase
    {
        public event PropertyChangedEventHandler ChildrenPropertyChanged;
        protected override void ClearItems()
        {
            base.ClearItems();
    
            foreach (var item in this)
            {
                DisposeItem(item);
            }
        }
    
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            item.PropertyChanged += Model_PropertyChanged;
        }
    
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            DisposeItem(this[index]);
        }
    
        private void DisposeItem(ModelBase model)
        {
            model.PropertyChanged -= Model_PropertyChanged;
        }
    
        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ChildrenPropertyChanged.Invoke(sender, e);
        }
    }
