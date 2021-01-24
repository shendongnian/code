    public class DataModel
    {
        public int Qt_ID { get; set; }
        public string EnteryDate { get; set; }
        public string Purpose { get; set; }
        public Quotation[] Quot { get; set; }
        public string AddNew { get; set; }
    }
    public class Quotation
    {
        public int Qt_Dt_ID { get; set; }
        public int Srno { get; set; }
        public string PartyName { get; set; }
        public bool IsMature { get; set; }
    }
