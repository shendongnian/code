    string hourSalary = gv.DataKeys[i].Values[1].ToString();
    double salary = 0;
    if (!double.TryParse(hourSalary, out salary))
    {
      salary = 0; // Set your default value here
    }
    row["Hour_Salary"] = salary;
