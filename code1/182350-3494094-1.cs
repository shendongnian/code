     private void meFilter_Loaded(object sender, RoutedEventArgs e)
        {
            QueryClient qc = new QueryClient("BasicHttpBinding_IQuery");    
            qc.GetDepartmentsCompleted += new EventHandler<GetDepartmentsCompletedEventArgs>(qc_GetDepartmentsCompleted);
            qc.GetDepartmentsAsync();
        }
    public void qc_GetDepartmentsCompleted(object sender, GetDepartmentsCompletedEventArgs e)
        {
            DeptItems = new ObservableCollection<MeDepartment>(deptStaticItems.Concat<MeDepartment>(e.Result));
            DeptComboBox.ItemsSource = this.DeptItems;
            DeptComboBox.SelectedIndex = 0; 
        }
