    namespace DataTableToObjectMappper
    {
        public interface IMapper<T>
        {
            T MapDataRow(DataRow dr);
            List<T> MapDataTable(DataTable dt);
        }
    }
    //like employee mapper you need to create mapper for you object
    //you can also make use of reflection instead of going for each property as done below 
       public class EmployeeMapper : IMapper<Employee>
        {
            public Employee MapDataRow(DataRow dr)
            {
                Employee emp = new Employee()
                {
                    Id = ServiceUtil.GetColumnValue<float>("Id", dr),
                    Name = ServiceUtil.GetColumnValue<string>("Name", dr),
                    Address = ServiceUtil.GetColumnValue<int>("Address", dr),                
                };
                return emp;
            }
    
            public List<Employee> MapDataTable(DataTable dt)
            {
                List<Employee> lst = new List<Employee>();
                if (dt != null && dt.Rows != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lst.Add(MapDataRow(dr));
                    }
                }
                return lst;
            }
        }
        public static T GetColumnValue<T>(string columnName, DataRow dr)
        {
            Type typeParameterType = typeof(T);
            return dr.Table.Columns.Contains(columnName) && dr[columnName] != DBNull.Value
                ? (T) Convert.ChangeType(dr[columnName] , typeParameterType)
                : default(T);
        }
