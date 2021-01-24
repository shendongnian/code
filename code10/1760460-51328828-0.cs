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
