    string hourSalary = gv.DataKeys[i].Values[1].ToString();
    double salary;
    object salaryValue;
    if (double.TryParse(hourSalary, out salary))
    {
       salaryValue = salary;
    }
    else
    {
      salaryValue = DBNull.Value; // Store as a null
    }
    row["Hour_Salary"] = salaryValue;
