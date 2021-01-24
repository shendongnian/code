        private void FilterTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFilter();
        }
        private void UpdateFilter()
        {
            //NOTE: bellow comment only applies to DataGrids.
            //Calling commit or cancel edit twice resolves exceptions when trying to filter the DataGrid.
            //https://stackoverflow.com/questions/20204592/wpf-datagrid-refresh-is-not-allowed-during-an-addnew-or-edititem-transaction-m
            //CommitEdit();
            //CommitEdit();
            ICollectionView view = CollectionViewSource.GetDefaultView(Infos);
            if (view != null)
            {
                view.Filter = delegate (object item)
                {
                    if (item is ObjectInfo objectInfo)
                    {
                        return objectInfo.Text.Contains(FilterString);
                    }
                    return false;
                };
            }
        }
