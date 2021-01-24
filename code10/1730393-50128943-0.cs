    var employee = new Employee();
    bool isObjectValid = true;
    foreach(PropertyInfo propertyInfo in typeof(Employee).GetProperties())
    {
        if(propertyInfo.GetValue(employee) == null)
        {
            isObjectValid = false;
        }
    }
