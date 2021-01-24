     private void Order_bt_Click(object sender, RoutedEventArgs e)
        {
            DataTable data = ReadDataFromDB();
            if (data.Rows.Count <= 40)
            {
                // reserve the ticket to a person
            }
            else
            {
                MessageBox.Show("Sorry, the show is sold out");
            }
          
        }
