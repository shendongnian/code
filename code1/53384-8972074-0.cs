public class StreamReaderEx : StreamReader
{
    // NewLine characters (magic value -1: "not used").
    int newLine1, newLine2;
    // The last character read was the first character of the NewLine symbol AND we are using a two-character symbol.
    bool insideNewLine;
    // StringBuilder used for ReadLine implementation.
    StringBuilder lineBuilder = new StringBuilder();
    public StreamReaderEx(string path, string newLine = "\r\n") : base(path)
    {
        init(newLine);
    }
        
    public StreamReaderEx(Stream s, string newLine = "\r\n") : base(s)
    {
        init(newLine);
    }
    public string NewLine
    {
        get { return "" + (char)newLine1 + (char)newLine2; }
        private set
        {
            Guard.NotNull(value, "value");
            Guard.Range(value.Length, 1, 2, "Only 1 to 2 character NewLine symbols are supported.");
                
            newLine1 = value[0];
            newLine2 = (value.Length == 2 ? value[1] : -1);
        }
    }
    public int LineNumber { get; private set; }
    public int LinePosition { get; private set; }
    public override int Read()
    {
        int next = base.Read();
        trackTextPosition(next);
        return next;
    }
        
    public override int Read(char[] buffer, int index, int count)
    {
        int n = base.Read(buffer, index, count);
        for (int i = 0; i < n; i++)
        {
            trackTextPosition(buffer[i]);
        }
        return n;
    }
    public override string ReadLine()
    {
        int currentLine = LineNumber;
        lineBuilder.Length = 0;
        while (LineNumber == currentLine)
            lineBuilder.Append((char)Read());
        lineBuilder.Length -= (newLine2 == -1 ? 1 : 2);
        return lineBuilder.ToString();
    }
    void init(string newLine)
    {
        LineNumber = LinePosition = 1;
        NewLine = newLine;
    }
    void trackTextPosition(int next)
    {
        if (insideNewLine)
        {
            if (next == newLine2)
                nextLine();
            insideNewLine = false;
        }
        else
        {
            if (next == newLine1)
            {
                if (newLine2 == -1)
                    nextLine();
                else
                    insideNewLine = true;
            }
        }
        ++LinePosition;
    }
    void nextLine()
    {
        ++LineNumber;
        LinePosition = 0;
    }
}
