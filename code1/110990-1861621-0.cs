    [DllImport("userManager.dll")]
    static extern int GetUsers(ref USER_LIST userList);
    private static void Main()
    {
        // allocate space for user list
        USER_LIST uList = new USER_LIST();
        // allocate space for 10 user list items
        uList.NumUsers = 10; 
        uList.List = new USER_LIST_ITEM[uList.NumUsers];
        // get users
        GetUsers(ref uList);
    }
