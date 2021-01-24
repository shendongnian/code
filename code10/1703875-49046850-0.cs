    Aspose.Cells.Worksheet _sheetSummary = _book.Worksheets[6];
    ..........
    Aspose.Cells.Drawing.RadioButton radio = null;
     foreach (Shape item in _sheetSummary.Shapes)
                {
    
                    if (item.GetType().ToString() == "Aspose.Cells.Drawing.RadioButton")
                    {
    
                        radio = (Aspose.Cells.Drawing.RadioButton)item;
                        
    
                        if (radio.Name.Contains("obs2"))
                        {
                            radio.IsChecked = true;
                            
                        
                        }
                        
                        
                    }
                }
