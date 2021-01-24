    public UserViewModel userViewModel;
        public ChatRoom(UserViewModel userViewModel)
        {
            this.InitializeComponent();
            this.userViewModel = userViewModel;
            userViewModel.ChatTbl = chatTbl;
            userViewModel.CurrentView = CoreApplication.GetCurrentView();//this line
        }
