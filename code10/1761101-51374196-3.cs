        private void memberCollection_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            object collectionDataContext = memberCollection.DataContext;
            if (collectionDataContext != null)
            {
                DataObject dragData = new DataObject("DataContext", collectionDataContext);
                DragDrop.DoDragDrop(memberCollection, dragData, DragDropEffects.Move);
            }
        }
