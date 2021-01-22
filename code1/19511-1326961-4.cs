    protected System.Web.UI.WebControls.DataGrid DataGrid1;
    
    private void Page_Load(object sender, System.EventArgs e) {
    
      // call the parser
      DataTable dt=ParseCSVFile(Server.MapPath("./demo.csv"));			
      
      // bind the resulting DataTable to a DataGrid Web Control
      DataGrid1.DataSource=dt;
      DataGrid1.DataBind();
    }
