    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.Office.Interop;
    using Excel = Microsoft.Office.Interop.Excel;
     namespace WebApplication1
    {
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            //~~> Define your Excel Objects
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook;
            //~~> Start Excel and open the workbook.
            xlWorkBook = xlApp.Workbooks.Open("C:\\Users\\d.b.venkatachalam\\Desktop\\Macro.xlsm");
            xlApp.Visible = true;
            //~~> Run the macros by supplying the necessary arguments
            xlApp.Run("Macro");
        }
      }
    }
 
       
