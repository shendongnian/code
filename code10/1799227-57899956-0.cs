    private string WordReportGeneration(string docPath, string excelPath)
        {
            
            string[] chartTitles = new string[] {"","","","","","",.... };//Chart titles
            string[] bookMark = new string[] { "C1", "C2", "C3",..... };//rich text controls of the word doc
            for (int i = 0; i < chartTitles.Length; i++) //going through the chart title array
            {
                using (WordprocessingDocument myWordDoc = WordprocessingDocument.Open(docPath, true))
                {
                    MainDocumentPart mainPart = myWordDoc.MainDocumentPart;
                   
                    SdtBlock sdt = null;
                    mainPart.Document.Descendants<SdtBlock>().ToList().ForEach(b => {
                        var child = b.SdtProperties.GetFirstChild<Tag>();
                        if (child != null && child.Val.Equals(bookMark[i]))
                            sdt = b;
                    });
                    Paragraph p = sdt.SdtContentBlock.GetFirstChild<Paragraph>();
                    p.RemoveAllChildren();
                    Run r = new Run();
                    p.Append(r);
                    Drawing drawing = new Drawing();
                    r.Append(drawing);
                    Inline inline = new Inline(
                        new Extent()
                        { Cx = 5486400, Cy = 3200400 });
                    using (SpreadsheetDocument mySpreadsheet = SpreadsheetDocument.Open(excelPath, true))
                    {
                        WorkbookPart workbookPart = mySpreadsheet.WorkbookPart;
                        Sheet theSheet = workbookPart.Workbook.Descendants<Sheet>().FirstOrDefault(s => s.Name == "Report");
                        WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(theSheet.Id);
                        DrawingsPart drawingPart = worksheetPart.DrawingsPart;
                        ChartPart chartPart = (ChartPart)drawingPart.ChartParts.FirstOrDefault(x =>
                        x.ChartSpace.ChildElements[4].FirstChild.InnerText.Trim() == chartTitles[i]);
                        ChartPart importedChartPart = mainPart.AddPart<ChartPart>(chartPart);
                        string relId = mainPart.GetIdOfPart(importedChartPart);
                        DocumentFormat.OpenXml.Drawing.Spreadsheet.GraphicFrame frame = drawingPart.WorksheetDrawing.Descendants<DocumentFormat.OpenXml.Drawing.Spreadsheet.GraphicFrame>().First();
                        Graphic clonedGraphic = (Graphic)frame.Graphic.CloneNode(true);
                        ChartReference c = clonedGraphic.GraphicData.GetFirstChild<ChartReference>();
                        c.Id = relId;
                        DocProperties docPr = new DocProperties();
                        docPr.Name = "XXX";
                        docPr.Id = GetMaxDocPrId(mainPart) + 1;
                        inline.Append(docPr, clonedGraphic);
                        drawing.Append(inline);
                    }
                    myWordDoc.Save();
                    myWordDoc.Close();
                }
            }
            return docPath;
        }
