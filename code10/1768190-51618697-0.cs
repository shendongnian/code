    private void button1_Click(object sender, EventArgs e)
    {
        string StrQuery;
        DataTable ReturnInfoDataTable = new DataTable();
        dataGridView1.AllowUserToAddRows = false;
        using (var connection = new SqlConnection("Server=;Database=;Trusted_Connection=True;"))
        {
            connection.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string enteredCustomerNum = dataGridView1.Rows[i].Cells["Customer_Number"].Value.ToString();
                string enteredInvoiceNum = dataGridView1.Rows[i].Cells["Invoice_Number"].Value.ToString();
                string enteredRefundNum = dataGridView1.Rows[i].Cells["Refund_Number"].Value.ToString();
                string enteredCheckNum = dataGridView1.Rows[i].Cells["Check_Number"].Value.ToString();
                StrQuery = @"SELECT '" + enteredCheckNum + "' AS Check_Number, [Company_Num],[RHH_INV_NUMBER],[RHH_CUST_NUMBER],[RHH_RETURN_NUMBER],[RHH_CR_REFUND_NUM],[RHH_ENTERED_DATE],[RHH_DATE_POSTED],[RHH_DATE_RESOLVED] ,[TOTAL_AMOUNT] FROM[History_Warehouse].[dbo].[tbl_Return_Header] WHERE[RHH_CUST_NUMBER] = '" + enteredCustomerNum + "' AND[RHH_CR_REFUND_NUM] = '"+ enteredRefundNum + "' AND[RHH_RETURN_NUMBER] = '" + enteredInvoiceNum + "'";
                using (var command = new SqlCommand(StrQuery, connection))
                {
                    ReturnInfoDataTable.Load(command.ExecuteReader());
                }
            }
        }
