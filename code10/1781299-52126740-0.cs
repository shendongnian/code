        protected void Quantity_Update_Click(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvr.RowIndex;
            TextBox box4 = (TextBox)GridView1.Rows[index].FindControl("TextBox4");
            Label Label6 = (Label)GridView1.Rows[index].FindControl("Label6");
            int Quantity;
            bool qty = int.TryParse(box4.Text, out Quantity);
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string ProductNo = row.Cells[0].Text;
            if (Quantity > 0)
            {
                string CS;
                CS = "data source=LAPTOP-ODS96MIK\\MSSQL2014; database = Grocery_Demo; integrated security=SSPI";
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand("UpdateProductQuantity", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ProductQuantity", Quantity);
                cmd.Parameters.AddWithValue("@ProductNo", ProductNo);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox("Quantity has been updated");
                DisplayProducts();
            }
            else if (Quantity == 0 || qty == false)
            {
                Label6.Text = "Please add at least one quantity";
                DisplayProducts();
            }
        }
