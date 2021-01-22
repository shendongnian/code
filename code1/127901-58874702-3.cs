     int i = 0;
        private void add_in_grid(object sender, RoutedEventArgs e)
        {
            i = i + 1;
            System.Windows.Controls.TextBox newDepo = new System.Windows.Controls.TextBox();
                     
            newDepo.Name = "new_Depo_" + i;
            newDepo.Text = "neue Depo" + i;
           
            newDepo.Width = 200;
            newDepo.Height = 200;
           
            Grid.SetColumn(newDepo, i);
            Grid.SetRow(newDepo, 1);
          
            gridaxis.Children.Add(newDepo);
        }
        int k = 0;
        private void add_row_depo(object sender, RoutedEventArgs e)
        {
            k = k + 1;
            System.Windows.Controls.TextBox newRowDepo = new System.Windows.Controls.TextBox();
            newRowDepo.Name = "newRowDepo" + k;
            newRowDepo.Text = "row depo" + k;
            newRowDepo.Width = 200;
            newRowDepo.Height = 200;
            Grid.SetColumn(newRowDepo, k);
            Grid.SetRow(newRowDepo, 2);
            gridaxis.Children.Add(newRowDepo);
        }
