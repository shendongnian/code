    public void BindData()
    {
        dropDownList1.DataSource = LoadModelData();
        dropDownList1.DataValueField = "ModelID";
        dropDownList1.DataTextField = "ModelName";
        dropDownList1.DataBind();
    }
    public DataTable LoadModelData()
    { 
        DataSet dataset = new DataSet();
        using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleCs"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SP_GetModels", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CategoryID", SqlDbType.BigInt, 10).Value = CategoryID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, conn);
            adapter.Fill(dataset);
        }
        return dataset.Tables[0];
    }
