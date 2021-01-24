    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace Excel_Save_Over_Existing_File
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
           string fileTest = "C:\\Users\\Adil Aliyev\\Documents\\log.xlsx";
            if (File.Exists(fileTest))
            {
                File.Delete(fileTest);
            }
                Excel.Application oApp;
                Excel.Workbook oBook;
                Excel.Worksheet oSheet;
                oApp = new Excel.Application();
                oBook = oApp.Workbooks.Add();
                oSheet = (Excel.Worksheet)oBook.Worksheets.get_Item(1);
                oSheet.Cells[1, 1] = "1";
                oSheet.Cells[1, 2] = "0";
                oSheet.Cells[2, 1] = "0";
                oSheet.Cells[2, 2] = "1";
                oBook.SaveAs(fileTest);
                oBook.Close();
                oApp.Quit();
        
        }
    }
    }
