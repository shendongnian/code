    private void Prev_Click(object sender, RoutedEventArgs e)
    {
        ICollectionView view = CollectionViewSource.GetDefaultView(DataContext);
        if (view != null)
        {
            view.MoveCurrentToPrevious();
        }
    }
    
