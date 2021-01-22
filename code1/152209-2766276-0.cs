    // assume we already know it ends with %%EOF
    void AppendNumberToPdf(Stream stm, int number, bool addNewline)
    {
        stm.Seek(0, SeekOrigin.End); // go to EOF
        StreamWriter writer = new StreamWriter(stm, new ASCIIEncoding(), 1024);
        writer.WriteLine(string.Format("{0}% {1} {2}", (addNewLine ? "\n" : ""), kMyMarkerString, number));
        writer.Flush();
    }
