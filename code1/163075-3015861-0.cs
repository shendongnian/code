        private void QueryActivities()
        {
            QueryClient qc = new QueryClient("BasicHttpBinding_IQuery");
            QueryFilter filter = new QueryFilter();
            filter.CallForService = false;
            var result = qc.GetFilteredActivityIndex(filter);
  
            this.actGridView.ItemsSource = result; //binds to the gridview
        }
