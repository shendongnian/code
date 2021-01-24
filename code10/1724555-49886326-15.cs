    public class ValueChangingEventArgs<T> : EventArgs
    {
        public ValueChangingEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
        public T OldValue { get; private set; }
        public T NewValue { get; private set; }
    }
    public class ColumnHeaderViewModel : ViewModelBase
    {
        public ColumnHeaderViewModel(List<String> names, string name)
        {
            ColumnNames = names;
            ColumnName = name;
        }
        public List<String> ColumnNames { get; private set; }
        public event EventHandler<ValueChangingEventArgs<String>> NameChanging;
        #region ColumnName Property
        private String _columnName = default(String);
        public String ColumnName
        {
            get { return _columnName; }
            set
            {
                if (value != _columnName)
                {
                    var oldName = ColumnName;
                    _columnName = value;
                    OnPropertyChanged();
                    NameChanging?.Invoke(this, new ValueChangingEventArgs<string>(oldName, ColumnName));
                }
            }
        }
        #endregion ColumnName Property
        //  Rename without raising NameChanging
        public void Rename(string newName)
        {
            _columnName = newName;
            OnPropertyChanged(nameof(ColumnName));
        }
    }
