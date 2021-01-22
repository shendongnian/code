    using System;
    using System.ComponentModel;
    using System.Dynamic;
    using System.Linq;
    namespace EnumSelectorTest
    {
      public class EnumSelectorVM : DynamicObject, INotifyPropertyChanged
      {
        //------------------------------------------------------------------------------------------------------------------------------------------
        #region Fields
        private readonly Action<object> _action;
        private readonly Type _enumType;
        private readonly string[] _enumNames;
        private readonly bool _notifyAll;
        #endregion Fields
        //------------------------------------------------------------------------------------------------------------------------------------------
        #region Properties
        private object _value;
        public object Value
        {
          get { return _value; }
          set
          {
            if (_value == value) return;
            _value = value;
            RaisePropertyChanged("Value");
            _action?.Invoke(_value);
          }
        }
        #endregion Properties
        //------------------------------------------------------------------------------------------------------------------------------------------
        #region Constructor
        public EnumSelectorVM(Type enumType, object initialValue, bool notifyAll = false, Action<object> action = null)
        {
          if (!enumType.IsEnum)
            throw new ArgumentException("enumType must be of Type: Enum");
          _enumType = enumType;
          _enumNames = enumType.GetEnumNames();
          _notifyAll = notifyAll;
          _action = action;
          //do last so notification fires and action is executed
          Value = initialValue;
        }
        #endregion Constructor
        //------------------------------------------------------------------------------------------------------------------------------------------
        #region Methods
        //---------------------------------------------------------------------
        #region Public Methods
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
          string elementName;
          if (!TryGetEnumElemntName(binder.Name, out elementName))
          {
            result = null;
            return false;
          }
          try
          {
            result = Value.Equals(Enum.Parse(_enumType, elementName));
          }
          catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is OverflowException)
          {
            result = null;
            return false;
          }
          return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object newValue)
        {
          if (!(newValue is bool))
            return false;
          string elementName;
          if (!TryGetEnumElemntName(binder.Name, out elementName))
            return false;
          try
          {
            if((bool) newValue)
              Value = Enum.Parse(_enumType, elementName);
          }
          catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is OverflowException)
          {
            return false;
          }
          if (_notifyAll)
            foreach (var name in _enumNames)
              RaisePropertyChanged("Is" + name);
          else
            RaisePropertyChanged("Is" + elementName);
          return true;
        }
        #endregion Public Methods
        //---------------------------------------------------------------------
        #region Private Methods
        private bool TryGetEnumElemntName(string bindingName, out string elementName)
        {
          elementName = "";
          if (bindingName.IndexOf("Is", StringComparison.Ordinal) != 0)
            return false;
          var name = bindingName.Remove(0, 2); // remove first 2 chars "Is"
          if (!_enumNames.Contains(name))
            return false;
          elementName = name;
          return true;
        }
        #endregion Private Methods
        #endregion Methods
        //------------------------------------------------------------------------------------------------------------------------------------------
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Events
      }
    }
