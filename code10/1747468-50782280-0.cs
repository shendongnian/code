     public partial class Default: System.Web.UI.Page {  
        protected void Page_Load(object sender, EventArgs e) {  
        }  
        private DataTable getAllEmployeesList() {  
            string constr = ConfigurationManager.ConnectionStrings["RConnection"].ConnectionString;  
            using(SqlConnection con = new SqlConnection(constr)) {  
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM Employee ORDER BY ID")) {  
                    using(SqlDataAdapter da = new SqlDataAdapter()) {  
                        DataTable dt = new DataTable();  
                        cmd.CommandType = CommandType.Text;  
                        cmd.Connection = con;  
                        da.SelectCommand = cmd;  
                        da.Fill(dt);  
                        return dt;  
                    }  
                }  
            }  
        }  
        private DataTable getAllEmployeesOrderList() {  
            string constr = ConfigurationManager.ConnectionStrings["RConnection"].ConnectionString;  
            using(SqlConnection con = new SqlConnection(constr)) {  
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM OrderDetails ORDER BY Order_ID")) {  
                    using(SqlDataAdapter da = new SqlDataAdapter()) {  
                        DataTable dt = new DataTable();  
                        cmd.CommandType = CommandType.Text;  
                        cmd.Connection = con;  
                        da.SelectCommand = cmd;  
                        da.Fill(dt);  
                        return dt;  
                    }  
                }  
            }  
        }  
        public DataSet getDataSetExportToExcel() {  
            DataSet ds = new DataSet();  
            DataTable dtEmp = new DataTable("Employee");  
            dtEmp = getAllEmployeesList();  
  
            DataTable dtEmpOrder = new DataTable("Order List");  
            dtEmpOrder = getAllEmployeesOrderList();  
            ds.Tables.Add(dtEmp);  
            ds.Tables.Add(dtEmpOrder);  
            return ds;  
        }  
        protected void btn_Export_Click(object sender, EventArgs e) {  
            DataSet ds = getDataSetExportToExcel();  
            using(XLWorkbook wb = new XLWorkbook()) {  
                wb.Worksheets.Add(ds);  
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;  
                wb.Style.Font.Bold = true;  
                Response.Clear();  
                Response.Buffer = true;  
                Response.Charset = "";  
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";  
                Response.AddHeader("content-disposition", "attachment;filename= EmployeeAndOrderReport.xlsx");  
                using(MemoryStream MyMemoryStream = new MemoryStream()) {  
                    wb.SaveAs(MyMemoryStream);  
                    MyMemoryStream.WriteTo(Response.OutputStream);  
                    Response.Flush();  
                    Response.End();  
                }  
            }  
        }  
    }  
