    public class Record
    {
        private Dictionary<int, string> items = new Dictionary<string, string>();
        private int count;
        public Record(int size)
        {
            // populate array with empty strings
            for(int i = 0; i <= size; i++)
                items.Add(i, String.Empty);
            count = size;
        }
        public string this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }
        public int PropertyCount { get { return size; } }
    }
    public interface IRecordParser
    {
        string FileName { get; set; }
        string[] GetHeadings();
        bool HasHeaders { get; set; }
        void GoToStart();
        Record ParseNextRecord();
    }
    public abstract class RecordParser
    {
        string FileName { get; set; }
        bool HasHeaders { get; set; }
        public abstract string[] GetHeadings();
        public abstract void GoToStart();
        public abstract Record ParseNextRecord();    
    }
    public class ExcelRecordParser() : RecordParser, IRecordParser
    {
        public ExcelRecordParser()
        {
        }
        public string[] GetHeadings()
        {
            if (HasHeaders)
            {
                // enumerate headers from first row of file
            }
            else
                // retrieve from settings file
        }
        public void GoToStart()
        {
            // navigate to first row (or +1 if HasHeaders is true)
        }
        public Record ParseNextRecord()
        {
            var headers = GetHeaders();
            var r = new Record(headers.Length);
            for(int i = 0; i <= headers.Length; i++)
                r[i] = col[i];
        }
    }
    public class CsvRecordParser : RecordParser, IRecordParser
    {
        public CsvRecordParser()
        {
        }
        public string[] GetHeadings()
        {
            if (HasHeaders)
            {
                // enumerate headers from first row of file
            }
            else
                // retrieve from settings file
        }
        public void GoToStart()
        {
            // navigate to start of file (or +1 if HasHeaders is true)
        }
        public Record ParseNextRecord()
        {
            var headers = GetHeaders();
            var r = new Record(headers.Length);
            for(int i = 0; i <= headers.Length; i++)
                r[i] = line[i];
        }
    }
    public static class RecordParserFactory
    {
        public IRecordParser Create(string ext)
        {
            switch (ext)
            {
                case '.xls':
                    return new ExcelRecordParser() as IRecordParser;
                case '.csv':
                    return new CsvRecordParser() as IRecordParser;
            }
        }
    }
