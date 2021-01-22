    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using System.Reflection;
    namespace FilterLists
    {
        public class Program
        {
            static void Main(string[] args)
            {
                // set up the bunk json
                var filters = new Dictionary<string, object>();
                filters.Add("PositionId", "12345");
                string json = JsonConvert.SerializeObject(filters);
                // what's it look like as a string?
                Console.WriteLine(json);
                // take the json string and stuff it to our method.
                var result = GetStaffingPosition(json);
                Console.WriteLine(result.Count);
            }
        public static List<StaffingPositionsDataContract> GetStaffingPosition(string searchFilters)
        {
            var filters = JsonConvert.DeserializeObject<Dictionary<string, object>>(searchFilters).ToList();
            var contracts = StaffingPositionsDataContract.LoadMockData();
            List<StaffingPositionsDataContract> result = new List<StaffingPositionsDataContract>();
            
            foreach (var filter in filters)
            {
                foreach (var contract in contracts)
                {
                    PropertyInfo info = typeof(StaffingPositionsDataContract).GetProperty(filter.Key);
                    var propType = info.PropertyType;
                    if (info.GetValue(contract, null).Equals(Convert.ChangeType(filter.Value, propType)))
                    {
                        result.Add(contract);
                    }
                }
            }
            return result;
        }
    }
    [Serializable]
    public class StaffingPositionsDataContract
    {
        public int PositionId { get; set; }
        public string Series { get; set; }
        public string BFY { get; set; }
        public string BudgetStatus { get; set; }
        public string DutyStation { get; set; }
        public string OrgLocation { get; set; }
        public string BudgetingEntity { get; set; }
        public string FieldName { get; set; }
        public static List<StaffingPositionsDataContract> LoadMockData()
        {
            List<StaffingPositionsDataContract> staffingposition = new List<StaffingPositionsDataContract>()
            {
                new StaffingPositionsDataContract() {PositionId = 12345, Series="", BFY="FY2010", BudgetStatus="Actual", DutyStation="", OrgLocation="", BudgetingEntity=""},
                new StaffingPositionsDataContract() {PositionId = 67891, Series="", BFY="FY2011", BudgetStatus="Actual", DutyStation="", OrgLocation="", BudgetingEntity=""},
                new StaffingPositionsDataContract() {PositionId = 12345, Series="", BFY="FY2010", BudgetStatus="Projected", DutyStation="", OrgLocation="", BudgetingEntity=""},
                new StaffingPositionsDataContract() {PositionId = 67892, Series="", BFY="FY2011", BudgetStatus="Projected", DutyStation="", OrgLocation="", BudgetingEntity=""},
                new StaffingPositionsDataContract() {PositionId = 987654, Series="", BFY="FY2010", BudgetStatus="Projected", DutyStation="", OrgLocation="", BudgetingEntity=""}
            };
            return staffingposition;
        }
    }
    }
