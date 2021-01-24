    private async void AddButton_Click(object sender, RoutedEventArgs e)
    {
        var menuFlyout = new MenuFlyout();
        AddButton.Flyout = menuFlyout;
        List<ClientList> clientLists;
        var jsonSerializer = new DataContractJsonSerializer(typeof(List<ClientList>));
    
    
        var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(CLIENTSLIST);
    
        clientLists = (List<ClientList>)jsonSerializer.ReadObject(myStream);
    
        int isEmpty = myGrid.Children.Count;
        if (isEmpty == 0)
        {
            foreach (var device in clientLists)
            {
                var menuFlyoutItem = new MenuFlyoutItem() { Name = device.clientname, Text = device.clientname };
                menuFlyoutItem.Tag = device.clientaddress;
                menuFlyoutItem.Click += AddMenuFlyoutItem_Click;
                menuFlyout.Items.Add(menuFlyoutItem);
            }
        }else
        {
            foreach (var device in clientLists)
            {
                bool toAddButton = true;
                foreach (Button btn in myGrid.Children.OfType<Button>())
                {
                    if (btn.Content.ToString() == device.clientname)
                    {
                        toAddButton = false;
                    }
                }
                if (toAddButton)
                {
                    var menuFlyoutItem = new MenuFlyoutItem() { Name = device.clientname, Text = device.clientname };
                    menuFlyoutItem.Tag = device.clientaddress;
                    menuFlyoutItem.Click += AddMenuFlyoutItem_Click;
                    menuFlyout.Items.Add(menuFlyoutItem);
                }
            }
        }
    }
