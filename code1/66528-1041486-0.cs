    //*************************************************
    // 
    // Author:
    //	Ryan Van Aken (vanakenr@msn.com)
    // (C) 2009 Ryan Van Aken
    // 
    //
    // Permission is hereby granted, free of charge, to any person obtaining
    // a copy of this software and associated documentation files (the
    // "Software"), to deal in the Software without restriction, including
    // without limitation the rights to use, copy, modify, merge, publish,
    // distribute, sublicense, and/or sell copies of the Software, and to
    // permit persons to whom the Software is furnished to do so, subject to
    // the following conditions:
    // 
    // The above copyright notice and this permission notice shall be
    // included in all copies or substantial portions of the Software.
    // 
    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    // EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    // MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    // NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    // LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    // OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    // WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
    //
    //*************************************************
    
    
    
    //SQL Connection Settings -----------
    public string strConn = ConfigurationManager.ConnectionStrings["BLAH-Here"].ConnectionString;
    //-----------------------------------
    
    protected void Page_Load(object sender, EventArgs e)
    {
    //Grab the same data as the datagrid [report view] on the reporting page
    //Then set the "ContentType" to "application/vnd.ms-excel" which will generate the .XSL file
    
    //---Retrieve the Report from SQL, drop into DataSet, then Bind() it to a DataGrid
    SqlConnection conn = new SqlConnection(strConn);
    conn.Open();
    SqlDataAdapter cmd1 = new SqlDataAdapter("EXEC [dbo].[spStatReport] @CompanyID=" + Session["CompanyID"] + ", @StatReportID=" + Request.QueryString["ReportID"].ToString() + ", @StartDate='" + Request.QueryString["StartDate"].Replace("-", "/").ToString() + "', @EndDate='" + Request.QueryString["EndDate"].Replace("-", "/").ToString() + "';", conn);
    cmd1.SelectCommand.CommandType = CommandType.Text;
    DataSet dsReports = new DataSet("tblReporting");
    cmd1.Fill(dsReports);
    conn.Close();
    
    DataGrid dtaFinal = new DataGrid();
    dtaFinal.DataSource = dsReports.Tables[0];
    dtaFinal.DataBind();
    
    dtaFinal.HeaderStyle.ForeColor = System.Drawing.Color.White;
    dtaFinal.HeaderStyle.BackColor = System.Drawing.Color.DarkGray;
    dtaFinal.ItemStyle.BackColor = System.Drawing.Color.White;
    dtaFinal.AlternatingItemStyle.BackColor = System.Drawing.Color.AliceBlue;
    
    
    //---Create the File---------
    Response.Buffer = true;
    Response.ClearContent();
    Response.ClearHeaders();
    
    //---For PDF uncomment the following lines----------
    //Response.ContentType = "application/pdf";
    //Response.AddHeader("content-disposition", "attachment;filename=FileName.pdf");
    
    //---For MS Excel uncomment the following lines----------
    //Response.ContentType = "application/vnd.ms-excel";
    //Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
    
    //---For MS Word uncomment the following lines----------
    //Response.ContentType = "application/vnd.word";
    //Response.AddHeader("content-disposition", "attachment;filename=FileName.doc");
    
    //---For CSV uncomment the following lines----------
    //Response.ContentType = "text/csv";
    //Response.AddHeader("content-disposition", "attachment;filename=FileName.csv");
    
    //---For TXT uncomment the following lines----------
    //Response.ContentType = "text/plain";
    //Response.AddHeader("content-disposition", "attachment;filename=FileName.txt");
    
    
    EnableViewState = false;
    
    StringWriter sw = new StringWriter();
    HtmlTextWriter hw = new HtmlTextWriter(sw);
    
    //---Renders the DataGrid and then dumps it into the HtmlTextWriter Control
    dtaFinal.RenderControl(hw);
    
    //---Utilize the Response Object to write the StringWriter to the page
    Response.Write(sw.ToString());
    Response.Flush();
    Response.Close();
    Response.End();
    }
