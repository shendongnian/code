    public List<StaffingPositionsDataContract> GetStaffingPosition(string searchFilters)
    {
        var filters = JsonConvert.DeserializeObject<List<StaffingPositionsDataContract>>(searchFilters);
        IList<StaffingPositionsDataContract> contracts = new StaffingPositionsDataContract().LoadMockData(searchFilters);
        return contracts;
    }
    [DataContract] [Serializable]
    public class StaffingPositionsDataContract
    {
        [DataMember(Order = 1)] public int PositionId { get; set; }
        [DataMember(Order = 2)] public string Series { get; set; }
        [DataMember(Order = 3)] public string BFY { get; set; }
        [DataMember(Order = 4)] public string BudgetStatus { get; set; }
        [DataMember(Order = 5)] public string DutyStation { get; set; }
        [DataMember(Order = 6)] public string OrgLocation { get; set; }
        [DataMember(Order = 7)] public string BudgetingEntity { get; set; }
        [DataMember(Order = 8)] public string SeriesTitle { get; set; }
        [DataMember(Order = 9)] public int PersonnelId { get; set; }
        [DataMember(Order = 10)] public string PositionStatus { get; set; }
        [DataMember] public int RecId { get; set; }
    
        public List<StaffingPositionsDataContract> LoadMockData(string searchfilters)
        {
            // filter the list returned here
            List<StaffingPositionsDataContract> staffingposition = new List<StaffingPositionsDataContract>()
            {
                new StaffingPositionsDataContract() {RecId=1, PositionId = 12345, Series="", BFY="FY2010", BudgetStatus="Actual", DutyStation="", OrgLocation="", BudgetingEntity=""},
                new StaffingPositionsDataContract() {RecId=2, PositionId = 67891, Series="", BFY="FY2011", BudgetStatus="Actual", DutyStation="", OrgLocation="", BudgetingEntity=""},
                new StaffingPositionsDataContract() {RecId=3,PositionId = 12345, Series="", BFY="FY2010", BudgetStatus="Projected", DutyStation="", OrgLocation="", BudgetingEntity=""},
                new StaffingPositionsDataContract() {RecId=4,PositionId = 67892, Series="", BFY="FY2011", BudgetStatus="Projected", DutyStation="", OrgLocation="", BudgetingEntity=""},
                new StaffingPositionsDataContract() {RecId=5,PositionId = 987654, Series="", BFY="FY2010", BudgetStatus="Projected", DutyStation="", OrgLocation="", BudgetingEntity=""}
            };
            return staffingposition;
        }
    }
