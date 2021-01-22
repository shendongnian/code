    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Web.Services;
    namespace CalculateService
    {
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [ToolboxItem(false)]
        public class Service1 : System.Web.Services.WebService
        {
            [WebMethod]
            public int CalcluateSum(List<int> listInt)
            {
                int sum = listInt.Sum();
                return sum;
            }
        }
    }
