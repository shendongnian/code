    AcroFields acroFields = reader.AcroFields;
    PdfDictionary v = acroFields.GetSignatureDictionary(name);
    if (v != null) {
        PdfString contents = v.GetAsString(PdfName.CONTENTS);
        byte[] embeddedSignatureObjectBytes = contents.GetOriginalBytes();
        [... process embeddedSignatureObjectBytes ...]
    }
