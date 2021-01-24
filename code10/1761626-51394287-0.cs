    int id = 0;
    void Payments ()
    {
        radioBtnList = GetData();
        radioBtnList.DataBind ();
    }
    protected void Page_Load (object sender, EventArgs e)
    {
      Payments();
      Response.Write(ViewState["id"]);
    }
    protected void radioBtnList_Changed (object sender, EventArgs e)
    {
       id = int.Parse (radioBtnList.SelectedItem.Text);
       ViewState["id"]=id;
    }
    protected void dgw_pagechange (object source, DataGridPageChangedEventArgs e)
    {
        dgw.CurrentPageIndex = e.NewPageIndex;
        dgw.DataBind();
    }
