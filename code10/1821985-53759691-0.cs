            ICollectionView yourCollectionView = new CollectionViewSource { Source = yourCollection }.View;
            ListCollectionView listCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(yourCollectionView);
            if (listCollectionView != null)
            {
                if (listCollectionView.IsAddingNew)
                {
                    listCollectionView.CommitNew();
                }
                if (listCollectionView.IsEditingItem)
                {
                    listCollectionView.CommitEdit();
                }
            }
