    public static List<String[]> ReadBase64BytesCsv(Byte[] data, Encoding encoding, Char separator, Boolean ignoreEmptyLines)
    {
        List<String[]> splitLines = new List<String[]>();
        using (MemoryStream ms = new MemoryStream(data))
        using (FromBase64Transform tr = new FromBase64Transform(FromBase64TransformMode.IgnoreWhiteSpaces))
        using (CryptoStream cs = new CryptoStream(ms, tr, CryptoStreamMode.Read))
        using (StreamReader sr = new StreamReader(cs, encoding))
        using (TextFieldParser tfp = new TextFieldParser(sr))
        {
            tfp.TextFieldType = FieldType.Delimited;
            tfp.Delimiters = new String[] { separator.ToString() };
            while (true)
            {
                try
                {
                    String[] curLine = tfp.ReadFields();
                    if (curLine == null)
                        break;
                    if (ignoreEmptyLines && (curLine.Length == 0 || curLine.All(x => String.IsNullOrEmpty(x) || String.IsNullOrEmpty(x.Trim()))))
                        continue;
                    splitLines.Add(curLine);
                }
                catch (MalformedLineException mfle)
                {
                    // do something with errors here.
                }
            }
        }
        return splitLines;
    }
