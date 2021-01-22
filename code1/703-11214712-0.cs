    public class clsCSVBuilder
    {
        protected int _CurrentIndex = -1;
        protected List<string> _Headers = new List<string>();
        protected List<List<string>> _Records = new List<List<string>>();
        protected const string SEPERATOR = ",";
        public clsCSVBuilder() { }
        public void CreateRow()
        {
            _Records.Add(new List<string>());
            _CurrentIndex++;
        }
        protected string _EscapeString(string str)
        {
            return string.Format("\"{0}\"", str.Replace("\"", "\"\"")
                                                .Replace("\r\n", " ")
                                                .Replace("\n", " ")
                                                .Replace("\r", " "));
        }
        protected void _AddRawString(string item)
        {
            _Records[_CurrentIndex].Add(item);
        }
        public void AddHeader(string name)
        {
            _Headers.Add(_EscapeString(name));
        }
        public void AddRowItem(string item)
        {
            _AddRawString(_EscapeString(item));
        }
        public void AddRowItem(int item)
        {
            _AddRawString(item.ToString());
        }
        public void AddRowItem(double item)
        {
            _AddRawString(item.ToString());
        }
        public void AddRowItem(DateTime date)
        {
            AddRowItem(date.ToShortDateString());
        }
        public static string GenerateTempCSVPath()
        {
            return Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().ToLower().Replace("-", "") + ".csv");
        }
        protected string _GenerateCSV()
        {
            StringBuilder sb = new StringBuilder();
            if (_Headers.Count > 0)
            {
                sb.AppendLine(string.Join(SEPERATOR, _Headers.ToArray()));
            }
            foreach (List<string> row in _Records)
            {
                sb.AppendLine(string.Join(SEPERATOR, row.ToArray()));
            }
            return sb.ToString();
        }
        public void SaveAs(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(_GenerateCSV());
            }
        }
    }
