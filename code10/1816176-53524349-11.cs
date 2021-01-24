    static class NetworkJoinViewModelFactory
    {
        public static NetworkJoinViewModel Create(NetworkJoin networkJoin)
        {
            switch (networkJoin) {
                case WorkgroupJoin workgroupJoin:
                    return new NetworkJoinViewModel {
                        JoinType = JoinType.Workgroup,
                        Name = workgroupJoin.Name
                    };
                case DomainJoin domainJoin:
                    return new NetworkJoinViewModel {
                        JoinType = JoinType.Domain,
                        Name = domainJoin.Name,
                        Username = domainJoin.Username,
                        Password = domainJoin.Password
                    };
                default:
                    return null;
            }
        }
    }
