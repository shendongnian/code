    public class Record
    {
        public Record(string company, string contact, string addr, string phone)
        {
            Company = company;
            Contact = contact;
            Address = addr;
            Phone = phone;
        }
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
    public interface IRecordParser
    {
        string FileName { get; set; }
        string[] GetHeadings();
        void GoToStart();
        Record ParseNextRecord();
    }
    public abstract class RecordParser
    {
        string FileName { get; set; }
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
            // enumerate column headers
        }
        public void GoToStart()
        {
            // navigate to first row
        }
        public Record ParseNextRecord()
        {
           // parse columns and extract data
           return new Record(col[0], col[1], col[2], col[3]);
        }
    }
    public class CsvRecordParser : RecordParser, IRecordParser
    {
        public CsvRecordParser()
        {
        }
        public string[] GetHeadings()
        {
            // enumerate headers from first row of file
        }
        public void GoToStart()
        {
            // navigate to start of file
        }
        public Record ParseNextRecord()
        {
           // parse each line and extract information
           return new Record(line[0], line[1], line[2], line[3]);
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
