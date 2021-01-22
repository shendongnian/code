    BindingList<EmployeeAdapter> empViews = new BindingList<EmployeeAdapter>();
    foreach (Employee emp in employees)
    {
        empViews.Add(new EmployeeAdapter(emp));
    }
    empViews.ListChanged +=
            (object sender, ListChangedEventArgs e) =>
                {
                    BindingList<EmployeeAdapter> employeeAdapters = 
                            sender as BindingList<EmployeeAdapter>;
                    if (employeeAdapters == null)
                        return;
                    switch (e.ListChangedType)
                    {
                        case ListChangedType.ItemAdded:
                            EmployeeAdapter added = employeeAdapters[e.NewIndex];
                            if (!employees.Contains(added.Employee))
                                employees.Remove(added.Employee);
                            break;
                        case ListChangedType.ItemDeleted:
                            EmployeeAdapter deleted = employeeAdapters[e.OldIndex];
                            if (employees.Contains(deleted.Employee))
                                employees.Remove(deleted.Employee);
                            break;
                        default:
                            break;
                    }
                };
