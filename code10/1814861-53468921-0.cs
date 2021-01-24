                for (int r = 0; r < rows.Count(); r++)
                {
                    var cells = rows[r].Elements<Cell>().ToList();
                    for (int c = 0; c < cells.Count(); c++)
                    {
                        SharedStringTablePart shareStringPart = spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                        SharedStringItem[] items = shareStringPart.SharedStringTable.Elements<SharedStringItem>().ToArray();
                        if (cells[c].DataType != null)
                        {
                            if (cells[c].CellValue != null)
                            {
                                int v = int.Parse(cells[c].CellValue.Text);
                                text = items[v].InnerText;
                            }
                        }
                        else
                            text = cells[c].CellValue?.Text;
