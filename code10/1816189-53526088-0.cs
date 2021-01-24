    public class NetworkJoinViewModel : INotifyPropertyChanged
    {
        private JoinType _joinType;
        private string _name;
        private string _domainUserName;
        private string _domainPassword;
        public NetworkJoinViewModel(INetworkJoin join) {
            _name = join.Name;
            if (join is DomainJoin domainJoin) {
                _joinType = JoinType.Domain;
                _domainUserName = domainJoin.Username;
                _domainPassword = domainJoin.Password;
            } else if (join is WorkgroupJoin workgroupJoin) {
                _joinType = JoinType.Workgroup;
                _domainUserName = "";
                _domainPassword = "";
            } else throw new ArgumentException("Unknown INetworkJoin implementation");
        }
        public JoinType JoinType {
            get { return _joinType; }
            set {
                _joinType = value;
                NotifyPropertyChanged(nameof(JoinType));
                NotifyPropertyChanged(nameof(IsUserNameEnabled));
                NotifyPropertyChanged(nameof(IsPasswordEnabled));
            }
        }
        public bool IsUserNameEnabled => _joinType == JoinType.Domain;
        public bool IsPasswordEnabled => _joinType == JoinType.Domain;
        // ... typical INPC implementations of Name, UserName, and Password
        public INetworkJoin GetModel() {
            if (_joinType == JoinType.Domain) {
                return new DomainJoin(Name, DomainUserName, DomainPassword);
            } else if (_joinType == JoinType.Workgroup) {
                return new WorkgroupJoin(Name);
            } else throw new InvalidOperationException("Unknown JoinType");
        }
    }
