    abstract class NetworkJoinViewModelBase
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public SecureString Password { get; set; }
        public abstract bool IsOkButtonEnabled { get; }
        public abstract void Join();
        public abstract NetworkJoin ToDomainModel();
    }
    class WorkgroupJoinViewModel : NetworkJoinViewModelBase
    {
        public override void Join() { /* TODO: implement */ }
        public override bool IsOkButtonEnabled => !String.IsNullOrEmpty(Name);
        public override NetworkJoin ToDomainModel()
        {
            return new WorkgroupJoin {
                Name = Name
            };
        }
    }
    class DomainJoinViewModel : NetworkJoinViewModelBase
    {
        private const int MinPasswordLength = 8;
        public override void Join() { /* TODO: implement */ }
        public override bool IsOkButtonEnabled =>
            !String.IsNullOrEmpty(Name) &&
            !String.IsNullOrEmpty(Username) &&
            Password != null && Password.Length >= MinPasswordLength;
        public override NetworkJoin ToDomainModel()
        {
            return new DomainJoin {
                Name = Name,
                Username = Username,
                Password = Password
            };
        }
    }
