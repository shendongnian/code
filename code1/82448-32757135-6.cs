    public class INPCBaseClass: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool changeProperty<T>(ref T field, T value,
            IEqualityComparer<T> comparer = null, [CallerMemberName] string propertyName = null)
        {
            return PropertyChanged.ChangeProperty(ref field, value, this, comparer, propertyName);
        }
    }
