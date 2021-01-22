&lt;%--ASP.NET Declarative--%&gt;
&lt;asp:FileUpload ID="FileUpload1" runat="server" /&gt;
&lt;asp:Button ID="Button1" runat="server" Text="Send File" OnClick="Button1_Click" /&gt;
&lt;asp:GridView ID="GridView1" runat="server" /&gt;
// C# Code-Behind
protected void Button1_Click(object sender, EventArgs e) {
    // the ExcelDataReader takes a System.IO.Stream object
    var excelReader = new ExcelDataReader(FileUpload1.FileContent);
    FileUpload1.FileContent.Close();
    DataSet wb = excelReader.WorkbookData;
    // get the first worksheet of the workbook
    DataTable dt = excelReader.WorkbookData.Tables[0];
    GridView1.DataSource = dt.AsDataView();
    GridView1.DataBind();
}
