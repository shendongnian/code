    public class ZRoleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ZRoleViewModel()
        {
            IRepository<Role> mRole = new Repository<Role>();
            _roles = new ObservableCollection<Role>(mRole.GetAll());
            SelectedIndex = -1;
            SelectedRole = new Role();
            _editRole = new ZRoleEditViewModel(SelectedRole);
            _editUC = new ZRoleEditUserControl(_editRole);
        }
        private ObservableCollection<Role> _roles;
        private Role _selectedRole;
        private int _selectedIndex;
        private ZRoleEditViewModel _editRole;
        private ZRoleEditUserControl _editUC;
        public ObservableCollection<Role> Roles
        {
            get => _roles;
            set
            {
                _roles = value;
                RaisePropertyChanged("Roles");
            }
        }
        public Role SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                RaisePropertyChanged("SelectedRole");
                if (_selectedRole != null && _editRole != null)
                {
                    _editRole.Role = _selectedRole;
                }
            }
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                RaisePropertyChanged("SelectedIndex");
            }
        }
        public ZRoleEditUserControl EditUC { get => _editUC; }
    }
