    class Program
    {
        static void Main(string[] args)
        {
            var fromDate = DateTime.Today.AddDays(2);
            var toDate = DateTime.Today.AddDays(5);
            var tempList = new List<UnassignWork>();
            tempList.Add(new UnassignWork { DateAssigned=DateTime.Today.AddDays(1)});
            tempList.Add(new UnassignWork { DateAssigned = DateTime.Today.AddDays(1) });
            tempList.Add(new UnassignWork { DateAssigned = DateTime.Today.AddDays(2) });
            tempList.Add(new UnassignWork { DateAssigned = DateTime.Today.AddDays(3) });
            tempList.Add(new UnassignWork { DateAssigned = DateTime.Today.AddDays(4) });
            tempList.Add(new UnassignWork { DateAssigned = DateTime.Today.AddDays(5) });
            tempList.Add(new UnassignWork { DateAssigned = DateTime.Today.AddDays(6) });
            tempList.Add(new UnassignWork { DateAssigned = DateTime.Today.AddDays(7) });
            tempList.Add(new UnassignWork { DateAssigned = DateTime.Today.AddDays(8) });
            //Lambda Operation
            var filterdList = tempList.Where(e => e.DateAssigned >= fromDate && e.DateAssigned <= toDate);
            //Linq Operation
            var filterdList2 = (from t in tempList
                                where t.DateAssigned >= fromDate && t.DateAssigned <= toDate
                                select t);
        }
    }
    public class UnassignWork
    {
        public int RecordNr { get; set; }
        public string GroupNum { get; set; }
        public string Section { get; set; }
        public string SubscriberID { get; set; }
        public decimal DedAmt { get; set; }
        public decimal CopayCoinsAmt { get; set; }
        public int BaseDed { get; set; }
        public int BaseOOP { get; set; }
        public string ClaimRespCode { get; set; }
        public string ClaimRejCode { get; set; }
        public DateTime VendorFileDate { get; set; }
        public string PackageCd { get; set; }
        public DateTime ClaimDOS { get; set; }
        public string WorkTypeCd { get; set; }
        public string AssignedTo { get; set; }
        public DateTime DateAssigned { get; set; }
    }
