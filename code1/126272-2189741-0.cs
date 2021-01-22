    public class CostPeriodDto : IPeriodCalculation
    {
        public decimal? a { get; set; }
        public decimal? b { get; set; }
        public decimal? c { get; set; }
        public decimal? d { get; set; }
    }
    public interface IPeriodCalculation
    {
        decimal? a { get; set; }
        decimal? b { get; set; }
    }
    public class myDto
    {
        public List<CostPeriodDto> costPeriodList { get; set; }
        public List<IPeriodCalculation> periodCalcList
        {
            get
            {
                return this.costPeriodList.Cast<IPeriodCalculation>().ToList();         
            }
        }
    }
