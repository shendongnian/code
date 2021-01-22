    public class PositionableStreamReader : StreamReader
    {
        public SeekableStreamReader(string path)
            :base(path)
            {}
        private int myLineEndingCharacterLength = Environment.NewLine.Length;
        public int LineEndingCharacterLength
        {
            get { return myLineEndingCharacterLength; }
            set { myLineEndingCharacterLength = value; }
        }
        public override string ReadLine()
        {
            string line = base.ReadLine();
            if (null != line)
                myStreamPosition += line.Length + myLineEndingCharacterLength;
            return line;
        }
        private long myStreamPosition = 0;
        public long Position
        {
            get { return myStreamPosition; }
            set
            {
                myStreamPosition = value;
                this.BaseStream.Position = value;
                this.DiscardBufferedData();
            }
        }
    }
