        private void MainTCList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
                TC item = (TC)MainTCList.Items.CurrentItem;
                Wyswietlacz.Content = item.UserTID;  
        }
