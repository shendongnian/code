    public partial class EmployeeRec
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    static void CSVTest()
    {
        string csv = @"Id, Name
    1, Carl
    2, Tom
    3, Mark";
    
        using (var p = ChoCSVReader<EmployeeRec>.LoadText(csv)
            .WithFirstLineHeader()
            )
        {
            foreach (var rec in p)
            {
                Console.WriteLine($"Id: {rec.Id}");
                Console.WriteLine($"Name: {rec.Name}");
            }
        }
    }
