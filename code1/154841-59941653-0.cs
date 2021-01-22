    private void btnBack_Click(object sender, EventArgs e)
        {
            int a = int.Parse(lblmin.Text);
            int b = int.Parse(lblmax.Text);
            int c = a - 100;
            int d = b - 100;
            if (lblmin.Text != "1")
            {
                String name = "Main";
                String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                "C:\\BBISDatabase\\Data.xlsx" +
                                ";Extended Properties='Excel 8.0;HDR=YES;';";
                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$] where IDs between " + c.ToString() + " and " + d.ToString() + "", con);
                con.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgMain.DataSource = data;
                lblcount.Text = c.ToString();
                lblmax.Text = d.ToString();
            }
            else
            {
                btnBack.Visible = false;
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            
            int a = int.Parse(lblmin.Text);
            int b = int.Parse(lblmax.Text);
            int c = b + 1;
            int d = b + 100;
            String name = "Main";
            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            "C:\\BBISDatabase\\Data.xlsx" +
                            ";Extended Properties='Excel 8.0;HDR=YES;';";
            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$] where IDs between "+c.ToString()+" and "+d.ToString()+"", con);
            con.Open();
            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dgMain.DataSource = data;
            lblmin.Text = c.ToString();
            lblmax.Text = d.ToString();
            btnBack.Visible = true;
        }
