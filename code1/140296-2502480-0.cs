    public IEnumerable<PropertyInfo> GetNotEqualsProperties(Employee emp1, Employee emp2)
    {
        Type employeeType = typeof (Employee);
        var properies = employeeType.GetProperties();
        foreach (var property in properies)
            if(!property.GetValue(emp1, null).Equals(property.GetValue(emp2, null))) //TODO: check for null
                yield return property;
    }
