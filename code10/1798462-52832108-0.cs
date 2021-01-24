     private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            List<ClientList> clientLists;
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<ClientList>));
            try
            {
                var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(CLIENTSLIST);
                clientLists = (List<ClientList>)jsonSerializer.ReadObject(myStream);
                var menuFlyout = new MenuFlyout();
                foreach (var device in clientLists)
                {
                    var menuFlyoutItem = new MenuFlyoutItem() { Name = device.clientname, Text = device.clientname };
                    menuFlyoutItem.Tag = device.clientname;
                    menuFlyoutItem.Click += MenuFlyoutItem_Click;
                    menuFlyout.Items.Add(menuFlyoutItem);
                }
                AddButton.Flyout = menuFlyout;
            }
            catch (Exception)
            {
                //Do nothing, file doesn't exist
            }
        }
        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuFlyoutItem;
            var deviceName = item.Tag;
            //TO DO SOMETHING
        }
    }
