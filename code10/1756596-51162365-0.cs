    foreach (var pdf in PDFDocInfo) {
        // create a "Document" element
        newDoc = new XElement("DOCUMENT",
            new XElement("Field_1", pdf.F1),
            new XElement("Field_2", pdf.F2),
            new XElement("Field_3", pdf.F3),
            new XElement("Field_4", pdf.F4),
        );
        // add any Address elements to newDoc
        foreach (var address in pdf.Address) {
            newDoc.Add(
                new XElement("Address",
                    new XElement("Item1", address.I1),
                    new XElement("Item2", address.I2));
            }
        }
        // add newDoc to Documents
        rootElement.Add(newDoc);
    }
