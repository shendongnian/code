    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using System.Xml;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    
    
    namespace Converter
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            public MainWindow()
            {
                InitializeComponent();
    
                //Read xml and fill dict
                XmlTextReader reader = new XmlTextReader("variablegroups.xml");
                string string_xml = "";
                string str1 = "ecatSource";
                string str2 = "name";
                bool inout = false;
    
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            string_xml = reader.Name;
                            break;
    
                        case XmlNodeType.Text:
                            if (string_xml.Equals(str1))
                            {
                                inout = true;
                            }
    
                            if ((string_xml.Equals(str1) || string_xml.Equals(str2)) && inout)
                            {
                                Console.Write(reader.Value); //write value
                                Console.Write("\n");
                                if (string_xml.Equals(str2))
                                {
                                    inout = false;
                                }
                            }
                            break;
                    }
                }
                Console.ReadLine();
    
    
                //Example for variables from XML
                //VarSymbolicDic.Add("-184K1 (CPX-FB38 64Byte).Outputs.QB2.Bit07","Run In Turntable Brake-High pressure");
                //VarSymbolicDic.Add("-184K1 (CPX-FB38 64Byte).Outputs.QB2.Bit08","Run In Turntable Brake-High pressure 2");
    
                //Read comment from excel
                string feecomment = "TIID.Device1.EtherCAT Simulation.-184K1 (CPX-FB38 64Byte).Outputs.QB2.Bit07";
    
                var result = feecomment.Replace("TIID.Device1.EtherCAT Simulation.", "");
                List<string> allcomments = new List<string>();
                allcomments.Add(result);
                /*
                foreach (string comment in allcomments)
                {
                    if (VarSymbolicDic.ContainsKey(comment))
                    {
                        //replace symbolic name in excel
                    }
                }*/
                //write to excel again
    
            }
        }
    
            public class ExcelFile
            {
                private string excelFilePath = @"N:\Dokumente\Bachelorarbeit\Dateien\Converter_Kopie\Converter\bin\Debug\Test_Excel.xls";
                private int rowNumber = 1; // define first row number to enter data in excel
    
                private Excel.Application myExcelApplication;
                private Excel.Workbook myExcelWorkbook;
                private Excel.Worksheet myExcelWorkSheet;
    
                public string GetExcelFilePath()
                { return excelFilePath; }
    
                public void SetExcelFilePath(string value)
                { excelFilePath = value; }
    
                public int GetRownumber()
                { return rowNumber; }
    
                public void SetRownumber(int value)
                { rowNumber = value; }
                public void OpenExcel()
                {
                    myExcelApplication = null;
    
                    myExcelApplication = new Excel.Application(); // create Excell App
                    myExcelApplication.DisplayAlerts = false; // turn off alerts
    
                    myExcelWorkbook = myExcelApplication.Workbooks._Open(excelFilePath, Missing.Value,
                       Missing.Value, Missing.Value,Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                       Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value); // open the existing excel file
    
                    int numberOfWorkbooks = myExcelApplication.Workbooks.Count; // get number of workbooks (optional)
    
                    myExcelWorkSheet = (Excel.Worksheet)myExcelWorkbook.Worksheets[1]; // define in which worksheet, do you want to add data
                    myExcelWorkSheet.Name = "WorkSheet 1"; // define a name for the worksheet (optinal)
    
                    int numberOfSheets = myExcelWorkbook.Worksheets.Count; // get number of worksheets (optional)
                }
    
                public void AddDataToExcel(string firstname, string lastname, string language, string email, string company)
                {
                    myExcelWorkSheet.Cells[rowNumber, "H"] = firstname;
                    myExcelWorkSheet.Cells[rowNumber, "J"] = lastname;
                    myExcelWorkSheet.Cells[rowNumber, "Q"] = language;
                    myExcelWorkSheet.Cells[rowNumber, "BH"] = email;
                    myExcelWorkSheet.Cells[rowNumber, "CH"] = company;
                    rowNumber++;  // if you put this method inside a loop, you should increase rownumber by one or what ever is your logic
                }
                public void closeExcel()
                {
                    try
                    {
                        myExcelWorkbook.SaveAs(excelFilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange,
                                                       Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value); // Save data in excel
    
                        myExcelWorkbook.Close(true, excelFilePath, Missing.Value); // close the worksheet
                    }
                    finally
                    {
                        if (myExcelApplication != null)
                        {
                            myExcelApplication.Quit(); // close the excel application
                        }
                    }
    
    
                }
            }
    }
