        public void Add(object sender, RoutedEventArgs e)
        {
            if (ulica.Text != "" && hisna_st.Text != "" && postna_st.Text != "" && obmocje.Text != "")
            {
                MessageBoxResult messageBoxResault = MessageBoxEx.Show(this, "Ali se prepričani?", "Potrditev vnosa", MessageBoxButton.YesNo);
                if (messageBoxResault == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        CommandText = "INSERT INTO cbu_naslovi VALUES ('" + ulica.Text + " " + hisna_st.Text + id_hise.Text + "','" + ulica.Text + "','" + hisna_st.Text + "','" + id_hise.Text + "','" + postna_st.Text + "','" + obmocje.Text + "','" + katastrska_obcina.Text + "','" + st_objekta.Text + "','" + st_delov.Text + "','" + st_parcele_1.Text + "','" + st_parcele_2.Text + "','" + st_parcele_3.Text + "','" + st_parcele_4.Text + "','" + st_parcele_5.Text + "','" + st_parcele_6.Text + "','" + st_parcele_7.Text + "','" + st_parcele_8.Text + "','" + st_parcele_9.Text + "','" + st_parcele_10.Text + "','" + st_parcele_11.Text + "','" + st_parcele_12.Text + "','" + st_parcele_13.Text + "','" + st_parcele_14.Text + "','" + st_parcele_15.Text + "','" + st_parcele_16.Text + "','" + st_parcele_17.Text + "'); SELECT SCOPE_IDENTITY();",
                        Connection = con
                    };
                    int lastId = Convert.ToInt32(cmd.ExecuteScalar());
                    InvokeDataGridAddress();
                    SetToRow(lastId);
                    address.Content = ulica.Text.ToString() + " " + hisna_st.Text.ToString() + id_hise.Text.ToString();
                }
            }
            else
            {
                MessageBoxEx.Show(this, "Vpisati je potrebno podatke!");
            }
        }
        public int CurrentID
        {
            get
            {
                int tmp = 0;
                if (dg_address.SelectedIndex >= 0)
                {
                    int.TryParse(dtAddress.Rows[dg_address.SelectedIndex].ItemArray[0].ToString(), out tmp);
                }
                return tmp;
            }
        }
        public void SetToRow(int Id)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            dg_address.SelectionChanged -= DG_Address_SelectionChanged;
            while (CurrentID != Id && dg_address.SelectedIndex < dtAddress.Rows.Count - 1)
            {
                dg_address.SelectedIndex++;
            }
            dg_address.SelectionChanged += DG_Address_SelectionChanged;
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }
