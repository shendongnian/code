    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    using System.Windows.Forms;
    namespace exceltry
      {
        public partial class Form1 : Form
         {
           public Form1()
            {
               InitializeComponent();
            }
    private void button1_Click(object sender, System.EventArgs e)
      {
            Microsoft.Office.Interop.Excel.Application xlexcel = null;
            Microsoft.Office.Interop.Excel._Workbook xlWorkbook = null;
            Microsoft.Office.Interop.Excel._Worksheet xlWorkSheet = null;
            Excel.Range oRng;
        try
           {
              //open existing workbook.
              xlexcel.Workbooks.Add("C:\\vehicledet.xlsx");
                xlWorkSheet = (Excel._Worksheet) xlWorkbook.ActiveSheet;
              //Get a new workbook.
              xlWorkbook = (Excel._Workbook)(oXL.Workbooks.Add( Missing.Value));  
              xlWorkSheet = (Excel._Worksheet) xlWorkbook.ActiveSheet;
             //Add table headers going cell by cell.
              xlWorkSheet.Cells[1, 1] = "Plate Number";
              xlWorkSheet.Cells[1, 2] = "Car Model";
              xlWorkSheet.Cells[1, 3] = "Car Brand";
              xlWorkSheet.Cells[1, 4] = "Mileage";
             //Format A1:D1 as bold, vertical alignment = center.
              xlWorkSheet.get_Range("A1", "D1").Font.Bold = true;
              xlWorkSheet.get_Range("A1", "D1").VerticalAlignment = 
              Excel.XlVAlign.xlVAlignCenter;
              // insert text at every last row
                int _lastRow = xlWorkSheet.Range["A" +    xlWorkSheet.Rows.Count].End[Excel.XlDirection.xlUp].Row + 1;
                xlWorkSheet.Cells[_lastRow, 1] = textBox1.Text;
                xlWorkSheet.Cells[_lastRow, 2] = textBox2.Text;
                xlWorkSheet.Cells[_lastRow, 3] = textBox3.Text;
                xlWorkSheet.Cells[_lastRow, 4] = textBox4.Text;
                //AutoFit columns A:D.
                oRng = xlWorkSheet.get_Range("A1", "D1");
                oRng.EntireColumn.AutoFit();
                //Make sure Excel is visible and give the user control of Microsoft Excel's lifetime.
                xlexcel.Visible = true;
                xlexcel.UserControl = true;
                xlWorkbook.Save();
                xlWorkbook.Close();
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Error");
            }
        }
    }
