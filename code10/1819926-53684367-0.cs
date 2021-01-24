    using System;
    using System.Windows.Forms;
    using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;
    using Workbook = Microsoft.Office.Interop.Excel.Workbook;
    using MsExcelApp = Microsoft.Office.Interop.Excel.Application;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            MsExcelApp xlApp =;
            Workbook xlWb;
            Worksheet xlSht;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string path = @"D:\test.xlsx";
                xlApp = new MsExcelApp();
    
    
                try
                {
                    xlWb = xlApp.Application.Workbooks.Open(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
        
                PM_Sheet1();
                PM_Sheet2();
    
                try
                {
                    xlWb.SaveAs(@"C:\Users\rchoj\OneDrive\Documenti\" + ComputerTxt.Text + ".xlsx");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
                xlApp.Quit();
            }
    
    
    
    
            protected void PM_Sheet1()
            {
                try
                {
                    xlSht = xlWb.Worksheets["PM"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
    
                xlSht.Cells[11, 2] = UserNameTxt.Text + "@rasatop.com";
                xlSht.Cells[11, 4] = UserNameTxt.Text;
                xlSht.Cells[14, 2] = SerialTxt.Text;
                xlSht.Cells[16, 2] = WLANMacTxt.Text;
                xlSht.Cells[16, 3] = LANMacTxt.Text;
                xlSht.Cells[16, 4] = IPTxt.Text;
                xlSht.Cells[14, 5] = ComputerTxt.Text;
                xlSht.Cells[16, 5] = BarcodeTxt.Text;
                xlSht.Cells[18, 5] = CPUTxt.Text.Substring(0, 26);
                xlsht.Cells[18, 4] = VGATxt.Text;
                xlsht.Cells[18, 3] = RAMTxt.Text;
                xlsht.Cells[27, 4] = OSTxt.Text;
                xlSht.Cells[5, 4] = System.DateTime.Today;
                xlSht.Cells[26, 4] = System.DateTime.Today;
                xlSht.Cells[9, 5] = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;
            }
            protected void PM_Sheet2()
            {
               try
                {
                    xlSht = xlWb.Worksheets["km"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
    
                xlSht.Cells[4, 2] = System.DateTime.Today;
                xlSht.Cells[6, 2] = UserNameTxt.Text;
                xlSht.Cells[6, 4] = ComputerTxt.Text;
                xlSht.Cells[6, 5] = BarcodeTxt.Text;
            }
        }
    
    
    }
