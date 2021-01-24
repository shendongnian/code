    class EmployeeMenuVM : EmployeeMenuVMBase
    {
        public EmployeeMenuVM()
        {
            var emptyPositions = new List<Global.Positions>()
            { Global.Positions.None };
            _rolePositions.Add(Global.Roles.None, emptyPositions);
            var customerServicePositions = new List<Global.Positions>()
            { Global.Positions.None, Global.Positions.CSS, Global.Positions.Manager };
            _rolePositions.Add(Global.Roles.CustomerService, customerServicePositions);
        }
        private Dictionary<Global.Roles, List<Global.Positions>> _rolePositions = new Dictionary<Global.Roles, List<Global.Positions>>();
        private string _roleStr;
        private string _posStr;
        private ObservableCollection<string> _pos = new ObservableCollection<string>(Enum.GetNames(typeof(Global.Positions)));
        private ObservableCollection<string> _role = new ObservableCollection<string>(Enum.GetNames(typeof(Global.Roles)));
        public ObservableCollection<string> Pos
        {
            get => _pos;
            set
            {
                SetProperty(ref _pos, value);
            }
        }
        public ObservableCollection<string> Role
        {
            get => _role;
        }
        public string RoleStr
        {
            get => _roleStr;
            set
            {
                if (SetProperty(ref _roleStr, value))
                {
                    Global.Roles role = (Global.Roles)Enum.Parse(typeof(Global.Roles), value);
                    var positions = _rolePositions[role].Select(p => p.ToString());
                    Pos = new ObservableCollection<string>(positions);
                }
            }
        }
        public string PosStr
        {
            get => _posStr;
            set => SetProperty(ref _posStr, value);
        }
    }
