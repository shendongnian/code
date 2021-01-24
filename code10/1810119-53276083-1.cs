        FlowDocument mcFlowDoc = new FlowDocument();
        // Set alignment
        mcFlowDoc.TextAlignment = TextAlignment.Center;
        // Create a paragraph with text  
        Paragraph para = new Paragraph();
        para.Inlines.Add(new Run("Flow Document\n"));
        para.Inlines.Add(new Bold(new Run("Content is not aligned\n.")));
        para.Inlines.Add(new Run("Vertical content alignment does not work in RichTextBox\n"));
        // Add the paragraph to blocks of paragraph  
        mcFlowDoc.Blocks.Add(para);
        // Set contents  
        richTextBox.Document = mcFlowDoc;
