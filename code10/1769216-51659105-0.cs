    static void Main(string[] args)
    {
        string path = @"CSVFile.csv";
        List<CSVData> data = new List<CSVData>();
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader sr = new StreamReader(fs))
            {
                sr.ReadLine();  // Header
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    while (line.EndsWith(","))
                    {
                        line += sr.ReadLine();
                    }
                    var items = line.Split(new string[] { "," }, StringSplitOptions.None);
                    data.Add(new CSVData() { CODE = items[0], NAME = items[1], COMPANY = items[2], DATE = items[3], ACTION = items[4] });
                }
            }
        }
        Console.ReadLine();
    }
    public class CSVData
    {
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string COMPANY { get; set; }
        public string DATE { get; set; }
        public string ACTION { get; set; }
    }
