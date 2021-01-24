    class NetworkJoinViewModel
    {
        private const int MinPasswordLength = 8;
        public JoinType JoinType { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public SecureString Password { get; set; }
        public bool IsOkButtonEnabled
        {
            get {
                switch (JoinType) {
                    case JoinType.Domain:
                        return
                            !String.IsNullOrEmpty(Name) &&
                            !String.IsNullOrEmpty(Username) &&
                            Password != null && Password.Length >= MinPasswordLength;
                    case JoinType.Workgroup:
                        return !String.IsNullOrEmpty(Name);
                    default:
                        return false;
                }
            }
        }
        public bool IsLoginEnabled => JoinType == JoinType.Domain; // For password an username textboxes.
        public void Join()
        {
            switch (JoinType) { /* ... */  }
        }
        public NetworkJoin ToDomainModel() {
            switch (JoinType) {
                case JoinType.Domain:
                    return new DomainJoin {
                        Name = Name,
                        Username = Username,
                        Password = Password
                    };
                case JoinType.Workgroup:
                    return new WorkgroupJoin {
                        Name = Name
                    };
                default:
                    return null;
            }
        }
    }
