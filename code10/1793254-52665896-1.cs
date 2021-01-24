    namespace Basware_Web_Service.Controllers
    {
        public class DepartmentDataController : ApiController
        {
            public DepartmentPClass.Items Get()
            {
                DepartmentPClass.Items items = new DepartmentPClass.Items();
                return items;
            }
        }
    }
