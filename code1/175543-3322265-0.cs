    namespace EorManager
    {
    public partial class _Default : System.Web.UI.Page
    {
        //Must be static
        static DataTable data = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //On FIRST page load I call my BindGridview method. 
            //Afterward I only call my BindGridview method from events
            if (!IsPostBack)
            {
                //make a column
                DataColumn myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "url";
                data.Columns.Add(myDataColumn);
                //add rows
                DataRow row;
                row = data.NewRow();
                row["url"] = "www.google.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.facebook.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.stackoverflow.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.google.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.facebook.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.stackoverflow.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.google.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.facebook.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.stackoverflow.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.google.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.facebook.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.stackoverflow.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.google.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.facebook.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.stackoverflow.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.google.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.facebook.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.stackoverflow.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.google.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.facebook.com";
                data.Rows.Add(row);
                row = data.NewRow();
                row["url"] = "www.stackoverflow.com";
                data.Rows.Add(row);
                
                BindGridview();
            }
        }
       
        private void BindGridview()
        {
            grdEOR.DataSource = data;
            grdEOR.DataBind();
        }
        protected void grdEor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEOR.PageIndex = e.NewPageIndex;
            BindGridview();
        }
    }
    }
