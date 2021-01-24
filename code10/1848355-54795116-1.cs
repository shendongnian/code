    using DocumentFormat.OpenXml.Packaging;
    using System.Linq;
    
    namespace ConsoleApp3
    {
        public class OpenXmlSolution
        {
            public void RemoveNames(string fullPathToFile)
            {            
                using (SpreadsheetDocument document = SpreadsheetDocument.Open(fullPathToFile, true))
                {
                    WorkbookPart wbPart = document.WorkbookPart;
                    var numOfNames = wbPart.Workbook.DefinedNames.Count();
                    if (numOfNames == 0) return;
                    for (int i = numOfNames -1 ; i >= 0; i--)
                    {
                        wbPart.Workbook.DefinedNames.ChildElements[i].Remove();
                    }                
                    wbPart.Workbook.Save();                
                }
            }
        }
    }
