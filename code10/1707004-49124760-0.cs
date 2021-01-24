    var o = new EmployeeLogReportListViewModel();
    var text = string.Join
    (
        ",",
        typeof(EmployeeLogReportListViewModel)
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Select
            (
                prop => prop.GetValue(o).ToString()
            )
    );
    Console.WriteLine(text);
