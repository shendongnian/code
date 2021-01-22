    class CostPeriodDtoCollection :
        Collection<CostPeriodDto>, 
        IEnumerable<IPeriodCalculation>
    {
    
        IEnumerable<IPeriodCalculation>.GetEnumerator() {
            foreach (IPeriodCalculation item in this) {
                yield return item;
            }
        }
    
    }
    
    class MyDto {
        public CostPeriodDtoCollection CostPeriods { get; set; }
        public IEnumerable<IPeriodCalculation> PeriodCalcList {
            get { return CostPeriods; }
        }
    }
