    class Program
    {
        static void Main(string[] args)
        {
            // usage:
            
            // note this wont run as getting streams is not Implemented
            // but will get you started
            CSVFileParser fileParser = new CSVFileParser();
            // TO Do:  configure fileparser
            PersonParser personParser = new PersonParser(fileParser);
            List<Person> persons = new List<Person>();
            // if the file is large and there is a good way to limit
            // without having to reparse the whole file you can use a 
            // linq query if you desire
            foreach (Person person in personParser.GetPersons())
            {
                persons.Add(person);
            }
            // now we have a list of Person objects
        }
    }
   
    public abstract  class CSVParser 
    {
        protected String[] deliniators = { "," };
        protected internal IEnumerable<String[]> GetRecords()
        {
            Stream stream = GetStream();
            StreamReader reader = new StreamReader(stream);
            String[] aRecord;
            while (!reader.EndOfStream)
            {
                  aRecord = reader.ReadLine().Split(deliniators, StringSplitOptions.None);
                  yield return aRecord;
            }
       
        }
        protected abstract Stream GetStream(); 
    
    }
    public class CSVFileParser : CSVParser
    {
        // to do: add logic to get a stream from a file
        protected override Stream GetStream()
        {
            throw new NotImplementedException();
        } 
    }
    public class CSVWebParser : CSVParser
    {
        // to do: add logic to get a stream from a web request
        protected override Stream GetStream()
        {
            throw new NotImplementedException();
        }
    }
    public class Person
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public DateTime DOB { get; set; }
    }
    public class PersonParser 
    {
        public PersonParser(CSVParser parser)
        {
            this.Parser = parser;
        }
        public CSVParser Parser { get; set; }
        public  IEnumerable<Person> GetPersons()
        {
            foreach (String[] record in this.Parser.GetRecords())
            {
                yield return new Person()
                {
                    Name = record[0],
                    Address = record[1],
                    DOB = DateTime.Parse(record[2]),
                };
            }
        }
    }
}
