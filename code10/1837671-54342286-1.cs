    protected void lnk_OnClick(object sender, EventArgs e)
        {
            int AdvertisementID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ViewByID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@AdvertisementID", AdvertisementID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            hfContactID.Value = AdvertisementID.ToString();
            AdsTb.Text = dtbl.Rows[0]["AdvertisementID"].ToString();
            itemTb.Text = dtbl.Rows[0]["Item"].ToString();
            ImageTb.Text = dtbl.Rows[0]["ImgPath"].ToString();
            //set image url of image control to display the image
            Image1.ImageUrl =  ImageTb.Text;
            ButSave.Text = "Update";
            btnDelete.Enabled = true;
        }
