    private void ListView_Loaded( object sender, RoutedEventArgs e )
    {
         // Add the handler to know when resizing a column is done
         ((ListView)sender).AddHandler( Thumb.DragCompletedEvent, new   DragCompletedEventHandler( ListViewHeader_DragCompleted ), true );
    }
    private void ListViewHeader_DragCompleted( object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e )
    {
         ListView lv = sender as ListView;
        ... code handing the resize goes here ...
    }
