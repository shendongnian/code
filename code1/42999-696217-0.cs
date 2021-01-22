    public static class Permissions
    {
        public const int CanComment = 0x1;
        public const int CanEdit = 0x2;
        public const int CanDelete = 0x4;
        public const int CanRemoveUsers = 0x8;
        public const int All = CanComment | CanEdit | CanDelete | CanRemoveUsers;
    }
