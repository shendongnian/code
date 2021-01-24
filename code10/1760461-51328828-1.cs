    public View2(View2ViewModel vm)
    {
        InitializeComponent();
        Messenger.Default.Register<NotificationMessage<int>>(this, (m) => NotificationMesageReceived(m, m.Content));
    }
    private void NotificationMesageReceived(NotificationMessage<int> msg, int divisionIdnt)
    {
        if (msg.Notification == "SearchCred")
        {
            var vm = new View2ViewModel();
            vm.DivisionIdnt = divisionIdnt;
            var findCredentialView = new View2(vm); 
            findCredentialView.ShowDialog();
        }
    }
