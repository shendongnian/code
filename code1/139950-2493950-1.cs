        void itemsControl_PreviewDragEnter(object sender, DragEventArgs e)
        {
            ItemsControl itemsControl = (ItemsControl)sender;
            if (e.Data.GetDataPresent(ItemType))
            {
                object data = e.Data.GetData(ItemType);
                InitializeDragAdorner(itemsControl, data, e.GetPosition(itemsControl));
                InitializeInsertAdorner(itemsControl, e);
            }
            e.Handled = true;
        }
