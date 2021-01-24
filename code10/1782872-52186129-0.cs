        class Program
        {
            static void Main(string[] args)
            {
                DataBase db = new DataBase();
                var sortedItems =
                    db.Jobs
                    .Where(x => x.JobStatus == "O")
                    .OrderBy(x => x.Material.MaterialCode).ThenBy(x => x.MaterialThickness).ThenBy(x => x.IdealSheetSize).ThenByDescending(x => x.DueDate)
                    .Select(x => new
                    {
                        x.JobNum,
                        x.Material.MaterialCode,
                        x.MaterialThickness,
                        x.Part.CustPartNum,
                        x.Part.CustName,
                        x.IdealSheetSize,
                        x.NbrOfSheets,
                        x.DueDate,
                        x.ShipmentNotes,
                        JobRoutings = x.JobRoutings.Select(e => new
                        {
                            e.ProcessID,
                            e.CrewSize,
                            e.PiecesPerHour,
                            e.OnHand,
                            e.PC,
                            e.LastScannedDate,
                            e.OpSeq
                        })
                    }).ToList();
                var groups = sortedItems.GroupBy(x => new { materialCode = x.MaterialCode, materialThickness = x.MaterialThickness })
                    .Select(x => new { job = x, count = x.Sum(y => y.NbrOfSheets) }).ToList();
            }
        }
        public class DataBase
        {
            public List<Job> Jobs { get; set; } 
        }
        public class Job
        {
            public string JobStatus { get; set; }
            public Material Material { get; set; }
            public string MaterialThickness { get; set; }
            public string IdealSheetSize { get; set; }
            public DateTime DueDate { get; set; }
            public int JobNum { get; set; }
            public Part Part { get; set; }
            public int NbrOfSheets { get; set; }
            public string ShipmentNotes { get; set; }
            public List<JobRoutings> JobRoutings { get; set; }
        }
        public class Material
        {
            public string MaterialCode { get; set; }
        }
        public class Part
        {
            public string CustPartNum { get; set; }
            public string CustName { get; set; }
        }
        public class JobRoutings
        {
            public string ProcessID {get;set;}
            public string CrewSize {get;set;}
            public string PiecesPerHour {get;set;}
            public string OnHand {get;set;}
            public string PC {get;set;}
            public string LastScannedDate {get;set;}
            public string OpSeq { get; set; }
        }
