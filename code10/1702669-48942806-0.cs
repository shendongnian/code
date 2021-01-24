    // Parent class
    public class Payer
    {
        public string Name { get; set; }
        public List<Status> Status { get; set; }
    }
    // Child class
    public class Status
    {
        public string Name { get; set; }
    }
    static void Main(params string[] args)
    {
        // Lets build some example-data
        List<Payer> payers = new List<Payer>()
        {
            new Payer()
            {
                Name = "Payer A",
                Status = new List<Status>()
                {
                    new Status() { Name = "Active" },
                    new Status() { Name = "Top" },
                    new Status() { Name = "Fast" }
                }
            },
            new Payer()
            {
                Name = "Payer B",
                Status = new List<Status>()
                {
                    // Payer B got no Status
                }
            }
        };
        var payerStatuses = payers.SelectMany
        (
            payer => payer.Status, // Select the Children
            (payer, stat) => new { Name = payer.Name, Status = stat.Name } // Tell Linq what to take from parent (payer) and what to take from child (status)
        );
        // let's see what we got
        foreach (var payerStatus in payerStatuses)
        {
            Console.WriteLine("Payer: {0}, Status: {1}", payerStatus.Name, payerStatus.Status);
        }
        // Expected:
        // "Payer: Payer A, Status: Active"
        // "Payer: Payer A, Status: Top"
        // "Payer: Payer A, Status: Fast"
    }
