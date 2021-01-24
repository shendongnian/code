        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!IsPageValid())
                {
                }
                else
                {
                    feesGroup_Model.Name = txtname.Text;
                    feesGroup_Model.Description = txtdiscription.Text;
                    feesGroups_ViewModel.FeesGroup_Insert(feesGroup_Model);
                    lstvwCustomerslist.ItemsSource = feesGroups_ViewModel.BindFeesGroupData(txtSearch1.Text);
                    txtname.Text = string.Empty;
                    txtdiscription.Text = string.Empty;
                    lblmsg.Visibility = Visibility.Hidden;
                    errorgrid.Visibility = Visibility.Collapsed;
                    bindpaggination();
                }
            }
            catch (Exception ex)
            {
                var abc = ex.ToString();
                throw;
            }
        }
