    ICollectionView RefineList()
        {
            DataSourceProvider provider = (DataSourceProvider)this.FindResource("Article");
            return CollectionViewSource.GetDefaultView(provider.Data);
        }
    		private void Unread_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = RefineList();
             if (view.Filter == null)
            {
                view.Filter = delegate(object item)
                {
                    return
                    int.Parse(((XmlElement)item).Attributes["read"].Value) == 0;
                };
            }
            else
            {
                view.Filter = null;
            }   
		}
