      ( (INotifyCollectionChanged)Items.SortDescriptions ).CollectionChanged += new NotifyCollectionChangedEventHandler( OnItemsSortDescriptionsChanged );
     private void OnItemsSortDescriptionsChanged( object sender, NotifyCollectionChangedEventArgs e )
        {
            //Synchronize effective sorting in the grid and Visual style on columns
            if ( Items != null )
            {
                foreach ( DataGridColumn column in Columns )
                {
                    column.SortDirection = null;
                    foreach ( SortDescription sd in Items.SortDescriptions )
                    {
                        if ( column.SortMemberPath == sd.PropertyName )
                        {
                            column.SortDirection = sd.Direction;
                            break;
                        }
                    }
                }
            }
        }
