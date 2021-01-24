       //Something like this,
      // Title is name of content control, value is what you want to add
      private static void UpdateControl(WordprocessingDocument document, string title, string value)
        {
            MainDocumentPart mainPart = document.MainDocumentPart;
            var sdtRuns = mainPart.Document.Descendants<SdtRun>()
            .Where(run => run.SdtProperties.GetFirstChild<Tag>().Val.Value == title);
            foreach (SdtRun sdtRun in sdtRuns)
            {
                sdtRun.Descendants<Text>().First().Text = value;
            }
            document.MainDocumentPart.Document.Save();
        }
