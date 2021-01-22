            ObservableCollection<EmployeeAdapter> observableEmployees = 
                        new ObservableCollection<EmployeeAdapter>();
            foreach (Employee emp in employees)
            {
                observableEmployees.Add(new EmployeeAdapter(emp));
            }
            observableEmployees.CollectionChanged += 
                (object sender, NotifyCollectionChangedEventArgs e) =>
                {
                    ObservableCollection<EmployeeAdapter> views = 
                            sender as ObservableCollection<EmployeeAdapter>;
                    if (views == null)
                        return;
                    switch (e.Action)
                    {
                         case NotifyCollectionChangedAction.Add:
                            foreach (EmployeeAdapter view in e.NewItems)
                            {
                                if (!employees.Contains(view.Employee))
                                    employees.Add(view.Employee);
                            }
                            break;
                         case NotifyCollectionChangedAction.Remove:
                            foreach (EmployeeAdapter view in e.OldItems)
                            {
                                if (employees.Contains(view.Employee))
                                    employees.Remove(view.Employee);
                            }
                            break;
                        default:
                            break;
                    }
                };
