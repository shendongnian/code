     RichTextBox rtbTest = new RichTextBox();
     rtbTest.IsDocumentEnabled = true;
     FlowDocument fd = new FlowDocument();
     Paragraph para = new Paragraph();
     Run r4 = new Run("Some Text To Show As Hyperlink");
     Hyperlink h4 = new Hyperlink(r4);
     h4.Foreground = Brushes.Red; //whatever color you want the HyperLink to be
     // If you want the Hyperlink clickable
     h4.NavigateUri = new Uri("Some URL");
     h4.RequestNavigate += new RequestNavigateEventHandler(h_RequestNavigate);
     // Leaving the two previous lines out will still make the Hyperlink, but it won't be clickable
     // use this if you don't want an underline under the HyperLink
     h4.TextDecorations = null;
     para.Inlines.Add(h4);
     fd.Blocks.Add(para);
     rtbTest.Document = fd;
