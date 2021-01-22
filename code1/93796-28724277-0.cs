    var doc = new FlowDocument();
    var p = new Paragraph();
    p.Inlines.Add(new Run("Hello "));
    p.Inlines.Add(new Hyperlink(new Run("777")));
    p.Inlines.Add(new Run(" world "));
    p.Inlines.Add(new Hyperlink(new Run("777")));
    doc.Blocks.Add(p);
