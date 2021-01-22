    class Record
    {
      public int Id { get; protected set; }
      public string Name { get; protected set; }
      public decimal Balance { get; protected set; }
      public DateTime Date { get; protected set; }
      public Record (int id, string name, decimal balance, DateTime date)
      {
        Id = id;
        Name = name;
        Balance = balance;
        Date = date;
      }
    }
    …
    Record[] records = from line in File.ReadAllLines(filename)
                       let fields = line.Split(',')
                       select new Record(
                         int.Parse(fields[0]),
                         fields[1],
                         decimal.Parse(fields[2]),
                         DateTime.Parse(fields[3])
                       ).ToArray();
    Record wantedRecord = records.Single(r => r.Name = clientName && r.Date = givenDate);
