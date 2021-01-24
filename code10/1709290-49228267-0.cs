        void bind()
        {
            
            string str = "select Driverc,Description,case when Liabilitiesc=0 then 'Payment' else 'Liabilities' end as Type,Amount,Date from Yourtable name";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ClintUsr.DataSource = dt;
                ClintUsr.DataBind();
             use for group which field you want-->   ShowingGroupingDataInGridView(Gridview1.Rows, 2, 1);
            }
            else
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add(new DataColumn("Yourdatacolum names", typeof(string)));
                dt1.Rows.Add(dt1.NewRow());
                Gridview1.DataSource = dt1;
                Gridview1.DataBind();
            }
            
        }
