     var ds = feesMaster_ViewModel.Dropdown_Feesgroup();
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpfeesgroup.ItemsSource = ds.Tables[0].DefaultView;
                drpfeesgroup.DisplayMemberPath = ds.Tables[0].Columns["name"].ToString();
                drpfeesgroup.SelectedValuePath = ds.Tables[0].Columns["id"].ToString();
            }
