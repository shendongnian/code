     b.Click += HandleButtonClick;
     clientDict.Add(b, null);
 
     private void HandleButtonClick(object sender, RoutedEventArgs e)
            {
                //Execute whatever you want from your client:
                var client = clientDict[sender as Button];
            }
