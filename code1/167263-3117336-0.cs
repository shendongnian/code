    protected void FillTheDropDownLists()
        {
            SqlApplication con = new SqlApplication();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT name FROM BT.dbo.Cartridge ORDER BY name", con.GetConnection());
                con.OpenSqlConnection();
    
                SqlDataReader reader = cmd.ExecuteReader();
                 DataTable dt = new DataTable();
                dt.Load(reader );
    
                blackList.DataValueField = "name";
                blackList.DataSource = dt ;
                blackList.DataBind();
    
                colorList1.DataValueField = "name";
                colorList1.DataSource = dt ;
                colorList1.DataBind();
    
                colorList2.DataValueField = "name";
                colorList2.DataSource = reader;
                colorList2.DataBind();
    
                colorList3.DataValueField = "name";
                colorList3.DataSource = dt ;
                colorList3.DataBind();
    
                otherColor1.DataValueField = "name";
                otherColor1.DataSource = dt ;
                otherColor1.DataBind();
    
                otherColor2.DataValueField = "name";
                otherColor2.DataSource = dt ;
                otherColor2.DataBind();
    
                otherColor3.DataValueField = "name";
                otherColor3.DataSource = dt ;
                otherColor3.DataBind();
    
                reader.Close();
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + err.Message);
            }
            finally
            {
                con.CloseSqlConnection();
            }
        }
