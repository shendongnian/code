    namespace TestConsoleApp
    {
        public class Record
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? ParentId { get; set; }
            public List<Record> ChildRecords { get; set; }
    
        }
        class Program
        {
            static void Main(string[] args)
            {
                var RecordsStore = new List<Record>();
    
                //Get the standalone recoreds
                var standaloneRecords = RecordsStore.Where(x => x.ParentId == null).Select(x => new Record
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildRecords = new List<Record>()
                });
    
                //Traverse
                List<Record> records = new List<Record>();
                foreach (var item in standaloneRecords)
                    records.Add(Traverse(item, RecordsStore));
    
            }
    
    
            private static Record Traverse(Record parent, List<Record> records)
            {
                parent.ChildRecords = records.Where(x => x.ParentId == parent.Id)
                                                  .Select(x => new Record
                                                  {
                                                      Id = x.Id,
                                                      Name = x.Name,
                                                      ChildRecords = new List<Record>()
                                                  }).ToList();
                foreach (var item in parent.ChildRecords)
                    Traverse(item, records);
                return parent;
            }
        }  
    }
