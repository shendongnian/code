    static void Main(string[] args)
    {
        SqlConnection cnnX = new SqlConnection("Data Source=r90jroughgarden\\;Initial Catalog=Sandbox;Integrated Security=True");
        SqlCommand cmdX = new SqlCommand("select * from tblToBeSorted", cnnX);
        cmdX.CommandType = CommandType.Text;
        SqlDataReader rdrX = null;
        if (cnnX.State == ConnectionState.Closed) cnnX.Open();
        int[,] aintSortingArray = new int[100, 4];     //i, elementid, planid, timeid
        try
        {
            //Load unsorted table data from DB to array
            rdrX = cmdX.ExecuteReader();
            if (!rdrX.HasRows) return;
            int i = -1;
            while (rdrX.Read() && i < 100)
            {
                i++;
                aintSortingArray[i, 0] = rdrX.GetInt32(0);
                aintSortingArray[i, 1] = rdrX.GetInt32(1);
                aintSortingArray[i, 2] = rdrX.GetInt32(2);
                aintSortingArray[i, 3] = rdrX.GetInt32(3);
            }
            rdrX.Close();
            DataTable dtblX = new DataTable();
            dtblX.Columns.Add("ChangeID");
            dtblX.Columns.Add("ElementID");
            dtblX.Columns.Add("PlanID");
            dtblX.Columns.Add("TimeID");
            for (int j = 0; j < i; j++)
            {
                DataRow drowX = dtblX.NewRow();
                for (int k = 0; k < 4; k++)
                {
                    drowX[k] = aintSortingArray[j, k];
                }
                dtblX.Rows.Add(drowX);
            }
            DataRow[] adrowX = dtblX.Select("", "ElementID, PlanID, TimeID");
            adrowX = dtblX.Select("", "ElementID desc, PlanID asc, TimeID desc");
        }
        catch (Exception ex)
        {
            string strErrMsg = ex.Message;
        }
        finally
        {
            if (cnnX.State == ConnectionState.Open) cnnX.Close();
        }
    }
