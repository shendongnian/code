      public static void Convert(System.Data.DataSet ds, System.Web.HttpResponse response)
        {
            //first let's clean up the response.object
            response.Clear();
            response.Charset = "";
            //set the response mime type for excel
            response.ContentType = "application/vnd.ms-excel";
            //create a string writer
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            
            
            //create an htmltextwriter which uses the stringwriter
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            //instantiate a datagrid
            System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
            //set the datagrid datasource to the dataset passed in
            dg.DataSource = ds.Tables[0];
            //bind the datagrid
            dg.DataBind();
    
    
            //tell the datagrid to render itself to our htmltextwriter
            dg.RenderControl(htmlWrite);
            //all that's left is to output the html
            response.Write(stringWrite.ToString());
            response.End();
        }
