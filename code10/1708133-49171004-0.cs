    public class MaledataDTO
    {
        public int MDid { get; set; }
        public int? BBid { get; set; }
        public decimal? Måling1 { get; set; }
        public decimal? Måling2 { get; set; }
        public decimal? Måling3 { get; set; }
        public decimal? Måling4 { get; set; }
        public DateTime? RegTid { get; set; }
        //... other properties
    }
    public IEnumerable<MaledataDTO> Get()
    {    
        using (var e = new SCTHDBEntities())
        {
            var result = e.Måledata.ToList();
            return Mapper.Map<List<MaledataDTO>>(result);
        }
    }
