    public class MyViewModel
    {
        public MyViewModel(List<AccountUserListView> userList, String bValue)
        {
            this.UserList = userList;
            this.BValue = bValue;
        }
        public List<AccountUserListView> UserList;
        public String BValue;
    }
