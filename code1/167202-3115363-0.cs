    protected override void OnInit(EventArgs e)
    {
        int i = 0;
        i = Int32.Parse(hdnTestCount.Value);
 
        if(Request.Params[hdnTestCount.UniqueID] != null)
        {
            i = Int32.Parse(Request.Params[hdnTestCount.UnitueID]);
        }
 
        for (int j = 1; j <= i; j++)
        {
             TextBox txtBox = new TextBox();
             txtBox.ID = "Test" + j.ToString();
             plhTest.Controls.Add(txtBox);
        }
    }
    protected void btnAdd_OnClick(object sender, EventArgs e)
    {
        int i = 0;
        i = Int32.Parse(hdnTestCount.Value) + 1;
        TextBox txtBox = new TextBox();
        txtBox.ID = "Test" + i.ToString();
        plhTest.Controls.Add(txtBox);
        hdnTestCount.Value = i.ToString();
    }
