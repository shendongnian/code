    public class ZRoleEditViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ZRoleEditViewModel(Role currentRole)
        {
            _role = currentRole;
        }
        private Role _role;
        public Role Role
        {
            get => _role;
            set
            {
                _role = value;
                RaisePropertyChanged("Role");
            }
        }
    }
