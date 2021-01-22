    Microsoft.Office.Interop.Excel.Workbook _workbook = Globals.ThisAddIn.Excel.CurrentWorkbook.InteropReference;
                Microsoft.Office.Interop.Excel.Range Target = (Microsoft.Office.Interop.Excel.Range)Globals.ThisAddIn.Application.ActiveCell;
                foreach (Microsoft.Office.Interop.Excel.Name name in _workbook.Names)
                {
                    Microsoft.Office.Interop.Excel.Range intersectRange = Globals.ThisAddIn.Excel.CurrentWorkbook.InteropReference.Application.Intersect(Target, name.RefersToRange);
                    if (Globals.ThisAddIn.Excel.CurrentWorkbook.InteropReference.Application.Intersect(name.RefersToRange, Target) != null)
                    {
                        rangeName = name.Name;
                        break;
                    }
                }
