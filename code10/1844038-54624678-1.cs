        public static void Display_Customer3(DataGridView dgv)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SalesInventoryManagement.Properties.Settings.Setting"].ConnectionString))
            {
                using (var cmd = new SqlCommand("usp_GetCustomers", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();     // Initiate the datatable here to avoid getting duplicate data during 'sda.Fill(dt)'
                        sda.Fill(dt);
                        var bsource = new BindingSource();
                        bsource.DataSource = dt;
                        dgv.DataSource = bsource;
                        //sda.Update(dt);
                    }
                    con.Close();
                }
            }
        }
