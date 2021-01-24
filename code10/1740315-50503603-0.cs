    public void Refreshdata(int selectedProduct, DateTime shiftStart, DateTime shiftEnd)
    {
        BizManager biz = new BizManager();
        GridView1.DataSource = biz.GetPacktstatisticsForShift(
              shiftStart
            , shiftEnd
            , selectedProduct).DefaultView;
        GridView1.DataBind();
    } 
    public void Dropdownlist1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime shiftStart = DateTime.Today;
        DateTime shiftEnd = DateTime.Today.AddDays(1).AddMinutes(-1);
        int productId;
            if(int.TryParse(DropDownList1.SelectedValue, out productId))
                Refreshdata(productId, shiftStart, shiftEnd);
    }
