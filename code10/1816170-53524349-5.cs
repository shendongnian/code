    static class NetworkJoinViewModelFactory
    {
        public static NetworkJoinViewModelBase Create(NetworkJoin networkJoin)
        {
            switch (networkJoin) {
                case WorkgroupJoin workgroupJoin:
                    return new WorkgroupJoinViewModel {
                        Name = workgroupJoin.Name
                    };
                case DomainJoin domainJoin:
                    return new DomainJoinViewModel {
                        Name = domainJoin.Name,
                        Username = domainJoin.Username,
                        Password = domainJoin.Password
                    };
                default:
                    return null;
            }
        }
    }
