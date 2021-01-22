    public static IList<MyClass> GetCustOrderHist(string someParameter)
        {
            IList<MyClass> data = ((IObjectContextAdapter)TestDashboardEntities).ObjectContext.ExecuteStoreQuery<MyClass>("CALL CustOrderHist({0});", someParameter).ToList();
            return data;
        }
        public class MyClass
        {
            public string ProductName { get; set; }
            public int TOTAL { get; set; }
        }
