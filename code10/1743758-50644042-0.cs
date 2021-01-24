        protected void CommodityList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal totalamount = 0;
        decimal taxamount = 0;
        for (int i = 0; i < CommodityList.Rows.Count; i++)
        {
            String total1 = (CommodityList.Rows[i].Cells[5].Text.Trim());
            totalamount += decimal.Parse(total1);
            String total2 = (CommodityList.Rows[i].Cells[6].Text.Trim());
            taxamount += decimal.Parse(total2);
            totalpayment = totalamount + taxamount;
        }
        txt_TotalAmount.Text = totalamount.ToString();
        txt_TotalTax.Text = taxamount.ToString();
        txt_TotalPayment.Text = totalpayment.ToString();
    }
