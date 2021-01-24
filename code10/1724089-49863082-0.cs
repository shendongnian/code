     private void Form1_Load(object sender, EventArgs e)
        {
            btnAccept.Enabled = false;
            lblOrderNo.Text = CurrentOrder.ToString();
            Price();
            //
            dataSource = @"Data Source =(LocalDB)\MSSQLocalDB;AttachDbFilename=|C:\Users\tyada\DATABASE\Pizza.mdf;";
            SqlParms = "Integrated Securtiy=True; Connect Timeout==30";
            string SqlCust = "select * from Customers";
            string strConn = dataSource + SqlParms;
            cnCust = new SqlConnection(strConn);
            cnCust.Open();
            TableCust = new DataTable();
            dtGridCust.DataSource = TableCust;
        }
