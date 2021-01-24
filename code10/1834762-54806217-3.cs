    AcroFields acroFields = reader.AcroFields;
    PdfDictionary v = acroFields.GetSignatureDictionary(name);
    if (v != null) {
        PdfArray b = v.GetAsArray(PdfName.BYTERANGE);
        RandomAccessFileOrArray rf = reader.SafeFile;
        Stream rg = null;
        try {
            rg = new RASInputStream(new RandomAccessSourceFactory().CreateRanged(rf.CreateSourceView(), b.AsLongArray()));
            [... process the signed data in the Stream rg ...]
        } finally {
            if (rg != null) rg.Close();
        }
    }
