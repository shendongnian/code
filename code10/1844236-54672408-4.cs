            using (SpreadsheetDocument document = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();
    
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();
    
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
    
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Template" };
    
                sheets.Append(sheet);
    
    
                var stylesheet = new Stylesheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
                stylesheet.AddNamespaceDeclaration("mc", "http: //schemas.openxmlformats.org/markup-compatibility/2006");
                stylesheet.AddNamespaceDeclaration("x14ac", "http: //schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
    
                var fills = new Fills() { Count = 5U };
                var fonts = new Fonts() { Count = 1U, KnownFonts = true };
              //  var cellFormats = new CellFormats() { Count = 4U };
                Font font = new Font();
                font.Append(new Color() { Rgb = "ff0000" });
                fonts.Append(font);
    
                //Fill fill = new Fill();
                //var patternFill = new PatternFill() { PatternType = PatternValues.Solid };
                //patternFill.Append(new ForegroundColor() { Rgb = "00ff00" });
                //patternFill.Append(new BackgroundColor() { Indexed = 64U });
                //fill.Append(patternFill);
                //fills.Append(fill);
    
              // cellFormats.AppendChild(new CellFormat() { FontId = 0U, FillId = 0U });
                stylesheet.Append(fonts);
                stylesheet.Append(fills);
             //  stylesheet.Append(cellFormats);
    
                var stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = stylesheet;
                stylePart.Stylesheet.Save();                  
    
                workbookPart.Workbook.Save();
    
               SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());
        
                // Constructing header
                Row row = new Row();
      
                foreach (DataExchangeDefinition a in importColList)
                {
                    defnExist = true;
                   row.Append(
                    ConstructCell(a.FieldCaption, CellValues.String));
                }
    
                if (defnExist == false)
                {
                    row.Append(
                    ConstructCell("Excel Template Definition Missing", CellValues.String));
    
                }
                // Insert the header row to the Sheet Data
                sheetData.AppendChild(row);
    
               // Inserting each employee
    
                worksheetPart.Worksheet.Save();
            }
        }
        catch (Exception)
        {
    
            throw;
        }
    }
    private Cell ConstructCell(string value, CellValues dataType)
    {
        Cell c = new Cell()
        {
            CellValue = new CellValue(value),
            DataType = new EnumValue<CellValues>(dataType)
           // StyleIndex=0U,
    
        };        
        return c;
    }
