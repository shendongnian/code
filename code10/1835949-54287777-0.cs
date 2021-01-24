        using (WordprocessingDocument document = WordprocessingDocument.CreateFromTemplate(txtWordFile.Text))
        {
            MainDocumentPart mainPart = pkgDoc.MainDocumentPart;
            SdtBlock block = mainPart.Document.Body.Descendants<SdtBlock>().Where
                (r => r.SdtProperties.GetFirstChild<Tag>().Val == "test1").FirstOrDefault();
            Text t = block.Descendants<Text>().Single();
            t.Text = "13,450,542";
            mainPart.Document.Save();
         }
