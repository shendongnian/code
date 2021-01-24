    private void btnCreateTable_Click(object sender, EventArgs e)
    {   
        string filePath = @"C:\X\TestCreateTAble.docx";
        using (WordprocessingDocument pkg = WordprocessingDocument.Open(filePath, true))
        {
            MainDocumentPart partDoc = pkg.MainDocumentPart;
            Document doc = partDoc.Document;
    
            StyleDefinitionsPart stylDefPart = partDoc.StyleDefinitionsPart;
            Styles styls = stylDefPart.Styles;
            Style styl = CreateTableCharacterStyle();
            stylDefPart.Styles.AppendChild(styl);
    
            Table t = new Table();
            TableRow tr = new TableRow();
    
            for (int i = 1; i <= 4; i++)
            {
                TableCell tc = new TableCell(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "500" }));
                Paragraph para = new Paragraph();
                ParagraphProperties paraProps = new ParagraphProperties();
                ParagraphMarkRunProperties paraRunProps = new ParagraphMarkRunProperties();
                RunStyle runStyl = new RunStyle() { Val = "Table9Point" };
                paraRunProps.Append(runStyl);
                //    FontSize runFont = new FontSize() {Val = "18" };
                //    paraRunProps.Append(runFont);
                paraProps.Append(paraRunProps);
                para.Append(paraProps);
    
                Run run = new Run();
    
                Text txt = null;
                if (i == 3)
                {
                }
                else
                {
                    txt = new Text("txt");
                    txt.Space = SpaceProcessingModeValues.Preserve;
                    RunProperties runProps = new RunProperties();
                    RunStyle inRunStyl = (RunStyle) runStyl.Clone();
                    runProps.Append(inRunStyl);
                    //    FontSize inRunFont = (FontSize) runFont.Clone();
                    //    runProps.Append(inRunFont);
                    run.Append(runProps);
                    run.Append(txt);
                    para.Append(run);
               }
                tc.Append(para);
                tr.Append(tc);
            }
            t.Append(tr);
            //Insert at end of document
            SectionProperties sectProps = doc.Body.Elements<SectionProperties>().LastOrDefault();
            doc.Body.InsertBefore(t, sectProps);
        }
    }
    
    private Style CreateTableCharacterStyle()
    {
        Style styl = new Style()
        {
            CustomStyle = true,
            StyleId = "Table9Point",
            Type = StyleValues.Character,
        };
        StyleName stylName = new StyleName() { Val = "Table9Point" };
        styl.AppendChild(stylName);
        StyleRunProperties stylRunProps = new StyleRunProperties();
        stylRunProps.FontSize = new FontSize() { Val = "18" };
        styl.AppendChild(stylRunProps);
        BasedOn basedOn1 = new BasedOn() { Val = "DefaultParagraphFont" };
        styl.AppendChild(basedOn1);
        return styl;
    }
