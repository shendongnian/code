    static class Mappings
    {
        private static Dictionary<Type, Dictionary<string, string>> TypeMappings;
        private static Dictionary<string, string> EmployeeMapping;
        //... other mapped classes
        static Mappings()
        {
            TypeMappings = new Dictionary<Type, Dictionary<string, string>>();
            EmployeeMapping = new Dictionary<string, string>();
            EmployeeMapping.Add("EmpID", "EmployeeID");
            EmployeeMapping.Add("EmpName", "EmployeeName");
            EmployeeMapping.Add("DeptID", "DepartmentID");
            TypeMappings.Add(typeof(Employee),EmployeeMapping);
            //... other mapped classes
        }
        public static string[] BuildValues<T>(T item)
        {
            if (!TypeMappings.ContainsKey(typeof(T)))
                throw new Exception("wrong call");
            Dictionary<string, string> mapping = TypeMappings[typeof(T)];
            List<string> results = new List<string>();
            foreach (var keyValuePair in mapping)
            {
                string propName = keyValuePair.Key;
                string dbName = keyValuePair.Value;
                PropertyInfo pi = typeof(T).GetProperty(propName);
                object propValue = pi.GetValue(item, null);
                results.Add(string.Format("{0}:{1}", dbName, propValue));
            }
            return results.ToArray();
        }
    }
