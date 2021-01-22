    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@".\Resources\Sample.xml");
            var columns = from column in doc.Descendants("COLUMNS").Descendants()
                          select new Column(column.Name.LocalName, int.Parse(column.Attribute("WIDTH").Value));
            foreach (var column in columns)
                Console.WriteLine(column.Name + " | " + column.Width);
        }
        class Column
        {
            public string Name { get; set; }
            public int Width { get; set; }
            public Column(string name, int width)
            {
                this.Name = name;
                this.Width = width;
            }
        }
    }
