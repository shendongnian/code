    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;
    using Excel = Microsoft.Office.Interop.Excel;
    using Microsoft.Office.Interop.Excel;
    using static MMCAPP2010.Profile;
    using System.Runtime.InteropServices;
    namespace MMCAPP2010
    {
        public class ExcelTemplateLoad
        {
            public void DeserializeObject(string filename)
            {
                Excel.Application instance;
                Workbook wb = null;
                try
                {
                    //getting the current running instance of an excel application
                    instance = (Excel.Application)Marshal.GetActiveObject("Excel.Application");   
                }
                catch
                {
                    instance = new Excel.Application();
                }
                //opening the template
                wb = instance.Workbooks.Open(@"C:\Users\U1152927\Downloads\sample.xltx");
