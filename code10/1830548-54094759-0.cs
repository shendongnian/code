           private void button1_Click(object sender, EventArgs e)
        {
            const string srcConnString = "data source=DESKTOP-Q8526KR;initial catalog=dentned;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            var csBuilder = new SqlConnectionStringBuilder(srcConnString);
            csBuilder.Remove("Integrated Security");
            csBuilder.UserID = "sa";
            csBuilder.Password = "sasa";
            var connString = csBuilder.ToString();
            SqlConnection sqlcon = new SqlConnection(connString);
            SqlDataAdapter sda = new SqlDataAdapter(srcConnString,sqlcon);
            DataTable dbdoc = new DataTable();
            sda.Fill(dbdoc);
            if (dbdoc.Rows.Count == 1) 
            {
                FormMain objfrmMain = new FormMain();
                this.Hide();
                if(dbdoc.Rows[0][8].ToString()!="admin")
                   
                {
                    objfrmMain.MainMenuStrip.Items[0].Visible = false;
                    objfrmMain.MainMenuStrip.Items[2].Visible = false;
                    objfrmMain.MainMenuStrip.Items[3].Visible = false;
                    objfrmMain.MainMenuStrip.Items[4].Visible = false;
                    objfrmMain.MainMenuStrip.Items[5].Visible = false;
                    objfrmMain.MainMenuStrip.Items[8].Visible = false;
                    
                }
                objfrmMain.Show();
            }
            else
            {
                MessageBox.Show("Username-i ose passwordi eshte gabim !!!!!!!!!!!!!!!!!!!");
            }
            
                     
        }
