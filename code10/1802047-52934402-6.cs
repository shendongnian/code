    public struct Listing
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
    using (var file = File.OpenText("test.txt"))
    {
        using (var csv = new CsvHelper.CsvReader(file))
        {
            csv.Configuration.Delimiter = "|";
            var records = csv.GetRecords<Listing>().ToList();
            foreach (var record in records)
            {
                Console.WriteLine("Name: {0}, Surname: {1}, Age: {2}", record.Name, record.Surname, record.Age);
            }
        }
    }
