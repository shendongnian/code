    public class Table
    {
        public string Name { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
    }
    public class foo
    {
        public string Name { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
            var inputData = new List<Table>
            {
                new Table{Name ="A1", Parameter="P1", Value="X"},
                new Table{Name ="A1", Parameter="P2", Value="Y"},
                new Table{Name ="A1", Parameter="P3", Value="Z"},
                new Table{Name ="A2", Parameter="P1", Value="XX"},
                new Table{Name ="A2", Parameter="P2", Value="YY"},
                new Table{Name ="A2", Parameter="P3", Value="ZZ"},
            };
            var groupedData = inputData.Where(y => y.Parameter == "P1" || y.Parameter == "P2" ).GroupBy(x => x.Name).ToList();
            var result = new List<foo>();
            foreach (var item in groupedData)
            {
                result.Add(new foo
                {
                    Name = item.FirstOrDefault().Name,
                    Value1 = item.FirstOrDefault().Value,
                    Value2 = item.Skip(1).FirstOrDefault().Value
                });
            }
            var result1 = result.OrderByDescending(x => x.Value1).ThenBy(x => x.Name);
