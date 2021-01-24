     public class BasePage : ContentPage
     {
       
        public ICommand CartItemCommand { get; set; }
        public ICommand NotificationPageCommand { get; set; }
        public BasePage() : base()
        {
            CartItemCommand = new Command(async () => await GoCartItemCommand());
            NotificationPageCommand = new Command(GoNotificationPage);
         
            Init();
        }
        private void Init()
        {
            this.ToolbarItems.Add(new ToolbarItem()
            {
                Icon = "nav_notification_btn",
                Command = NotificationPageCommand,
            });
            this.ToolbarItems.Add(new ToolbarItem()
            {
                Icon = "nav_cart_btn",
                Command = CartItemCommand
            });
        }
      
        }
    }
