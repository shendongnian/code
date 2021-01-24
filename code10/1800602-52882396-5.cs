    public class FieldViewModel : ViewModelBase
    {
        private object _instance;
        private FieldInfo _fieldInfo;
        private Type _fieldType;
        public FieldViewModel(object instance, FieldInfo fieldInfo)
        {
            _instance = instance;
            _fieldInfo = fieldInfo;
            _fieldType = fieldInfo.FieldType;
            IsReadOnly = fieldInfo.IsInitOnly || fieldInfo.IsLiteral;
            FieldName = fieldInfo.Name;
            TypeName = fieldInfo.FieldType.Name;
        }
        private bool _IsReadOnly;
        public bool IsReadOnly
        {
            get { return _IsReadOnly; }
            private set
            {
                _IsReadOnly = value;
                OnPropertyChanged();
            }
        }
        private string _fieldName;
        public string FieldName
        {
            get { return _fieldName; }
            set
            {
                _fieldName = value;
                OnPropertyChanged();
            }
        }
        private string _typeName;
        public string TypeName
        {
            get { return _typeName; }
            set
            {
                _typeName = value;
                OnPropertyChanged();
            }
        }
        public object Value
        {
            get
            {
                return _fieldInfo.GetValue(_instance);
            }
            set
            {
                _fieldInfo.SetValue(_instance, Convert.ChangeType(value, _fieldType));
                OnPropertyChanged();
            }
        }
    }
