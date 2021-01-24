    public class ViewModel : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, string> _validationErrors = new Dictionary<string, string>();
        private DateTime _periodStartDate;
        public DateTime PeriodStartDate
        {
            get { return _periodStartDate; }
            set { _periodStartDate = value; Validate(); }
        }
        private DateTime _periodEndDate;
        public DateTime PeriodEndDate
        {
            get { return _periodEndDate; }
            set { _periodEndDate = value; Validate(); }
        }
        private void Validate()
        {
            if (_periodStartDate > _periodEndDate)
                _validationErrors.Add(nameof(PeriodStartDate), $"{nameof(PeriodEndDate)} cannot be smaller than {nameof(PeriodStartDate)}");
            else
                _validationErrors.Clear();
            RaiseErrorsChanged(nameof(PeriodStartDate));
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void RaiseErrorsChanged(string propertyName) =>
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        public bool HasErrors => _validationErrors.Count > 0;
        public IEnumerable GetErrors(string propertyName)
        {
            string error;
            if (_validationErrors.TryGetValue(propertyName, out error))
                return new string[1] { error };
            return null;
        }
    }
