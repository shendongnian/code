           public static List<IEmployee> UpdateState<T>(List<T> employeesList, T employee, int newValue, string propertyToBeUpdated) where T : IEmployee
        {
            T myObject = employee;
            PropertyInfo propInfo = myObject.GetType().GetProperty(propertyToBeUpdated);
            propInfo.SetValue(employee, Convert.ChangeType(newValue, propInfo.PropertyType), null);
            employeesList.Insert(employeesList.Count, myObject);
            return ((IEnumerable<IEmployee>)employeesList).ToList();
        }
