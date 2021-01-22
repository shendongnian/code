    public unsafe struct USER_LIST
    {
        public uint numUsers;
        public USER_LIST_ITEM* list;
    }
    public unsafe struct USER_LIST_ITEM
    {
        public fixed byte name[260];
        public fixed byte address[256];
    }
    class Program
    {
        [DllImport("userManager.dll")]
        static unsafe extern int GetUsers(USER_LIST** userList);
        [DllImport("userManager.dll")]
        static unsafe extern int UMFree(USER_LIST* userList);
        private static unsafe void Main()
        {
            USER_LIST* list;
            GetUsers(&list);
            UMFree(list);
        }
    }
