    using System.Collections.Generic;
    using Excel = Microsoft.Office.Interop.Excel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    
    namespace ExcelMocking.Tests
    {
        [TestClass]
        public class UnitTest1
        {
            private List<Excel.Worksheet> worksheets = new List<Excel.Worksheet>();
    
            [TestMethod]
            public void TestMethod1()
            {
                var sheet = new Mock<Excel.Worksheet>();
                sheet.SetupGet(w => w.Name).Returns("2012");
                worksheets.Add(sheet.Object);
    
                sheet = new Mock<Excel.Worksheet>();
                sheet.SetupGet(w => w.Name).Returns("2013");
                worksheets.Add(sheet.Object);
    
                var sheetIndex = 0;
                var sheets = new Mock<Excel.Sheets>();
                sheets.Setup(s => s.Count).Returns(() => worksheets.Count);
                sheets.Setup(s => s[It.IsAny<object>()]).Callback<object>((theSheetIndex) =>
                {
                    // getting the real sheet index from the production code that starts from 1
                    // and simple subtracting -1 to get zero based index
                    sheetIndex = (int)theSheetIndex;
                    sheetIndex--;
                }).Returns(() => worksheets[sheetIndex]);
                
                sheets.Setup(s => s.GetEnumerator()).Returns(() => worksheets.GetEnumerator());
                sheets.As<Excel.Sheets>().Setup(s => s.GetEnumerator()).Returns(() => worksheets.GetEnumerator());
                
                var workbook = new Mock<Excel.Workbook>();
                workbook.Setup(w => w.Worksheets).Returns(sheets.Object);            
                            
                IDictionary<int, Excel.Worksheet> result = ExcelMocking.Class1.GetApplicableYearSheets(workbook.Object);
            }
        }
    }
