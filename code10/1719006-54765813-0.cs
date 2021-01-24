            int size = 3;
            DocX docX = DocX.Create(result, DocumentTypes.Document);
            Table table = docX.AddTable(size, size);
            table.AutoFit = AutoFit.Contents;            
            for (int i = 0; i < (int)TableBorderType.InsideV; i++)
                table.SetBorder((TableBorderType)i, new Border());
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    table.Rows[i].Cells[j].Paragraphs[0].InsertText(i + " | " + j);
            
            docX.InsertParagraph().InsertTableBeforeSelf(table);
            docX.Save();
