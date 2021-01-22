        private void OnMoveUp(object sender, RoutedEventArgs e)
        {
            ICollectionView myCollectView = CollectionViewSource.GetDefaultView(Orders);
            if (myCollectView.CurrentPosition > 0)
                myCollectView.MoveCurrentToPrevious();
            if (myCollectView.CurrentItem != null)
                theDataGrid.ScrollIntoView(myCollectView.CurrentItem);
        }
        private void OnMoveDown(object sender, RoutedEventArgs e)
        {
            ICollectionView  myCollectView = CollectionViewSource.GetDefaultView(Orders);
            if (myCollectView.CurrentPosition < Orders.Count)
                myCollectView.MoveCurrentToNext();
            if (myCollectView.CurrentItem !=null)
                theDataGrid.ScrollIntoView(myCollectView.CurrentItem);
        }
