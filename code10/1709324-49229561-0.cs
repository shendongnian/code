    var result = from d in yourList
                 group d by d.Date into grouped
                 select new DTO
                 {
                     Date = grouped.Key,
                     Val = grouped.Max()
                 };
    public class DTO 
    {
        public DateTime Date { get; set; }
        public int Val { get; set; }
    }
