        public ChatListModel chat;
        public MainWindow()
        {
            InitializeComponent();
            chat = new ChatListModel();
            chat.AddMessage(name, "Hello World!");
            MyChat.DataContext = chat;
            ChatTextControl.OnDeleteClick += ChatTextControl_OnDeleteClick;
        }
        private void ChatTextControl_OnDeleteClick(int id)
        {
            chat.DelMessage(id);
            MyChat.DataContext = null;
            MyChat.DataContext = chat;
        }
