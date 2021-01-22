protected void Page_Load(object sender, EventArgs e)
{    
    if (!Page.IsPostBack)
        {   
             LoadData()
        }
}
private void LoadData()
{
    labDownloadList.Text = null;
    //Session variables:    
    if (Session["Game"] != null)
    ...
}
protected void btnFilter_Click(object sender, EventArgs e)
{    
    game = lstGames.SelectedValue;
    modtype = lstTypeMod.SelectedValue;
    filter = true;
    LoadData();
}
