    public void Sort(Employee[] employees, string propertyName)
    {
            var desiredProperty = typeof(Employee).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo info = typeof(Employee).GetProperty(propertyName);
            if (info == null) { return; }
            for (int i = 1; i < employees.Length; i++)
            {
                Employee current = employees[i];
                int j = i - 1;
                int curValue = Convert.ToInt32(info.GetValue(current));
                int prevValue = Convert.ToInt32(info.GetValue(employees[j]));
                for (; j >= 0 && curValue > prevValue; j--)
                {
                    employees[j + 1] = employees[j];
                }
                employees[j + 1] = current;
            }
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
