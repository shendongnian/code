    StringBuilder sb = new StringBuilder();
    var fields = typeof(Employee).GetFields();
    for (int i = 0; i < fields.Length; ++i)
    {
        sb.Append(fields[i].GetValue(new Employee()));
        if (i < fields.Length - 1)
        {
            sb.Append(',');
        }
    }
    string result = sb.ToString();
    // The above will be "EMP_ID,FIRST_NAME,LAST_NAME,DEPT_ID"
