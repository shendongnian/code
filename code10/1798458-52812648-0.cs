        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var deviceList = JsonConvert.DeserializeObject<List<DeviceInfo>>(jsonData);
            var menuFlyout = new MenuFlyout();
            foreach (var device in deviceList)
            {
                var menuFlyoutItem = new MenuFlyoutItem() { Name = device.DeviceName, Text = device.DeviceName };
                menuFlyoutItem.Tag = device.DeviceName;
                menuFlyoutItem.Click += MenuFlyoutItem_Click;
                menuFlyout.Items.Add(menuFlyoutItem);
            }
            ButtonCreateDevice.Flyout = menuFlyout;
        }
        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuFlyoutItem;
            var deviceName = item.DeviceName;
            //TO DO SOMETHING
        }
