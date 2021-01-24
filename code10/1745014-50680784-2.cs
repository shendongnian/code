    private ListView GetListView(int index)
        {
            ListView listView = new ListView();
            listView.ItemsSource = //your list Source
            Frame frame = new Frame();
            frame.Margin = new Thickness(3);
           
            frame.Content = listView;
            return listView;
        }
 
