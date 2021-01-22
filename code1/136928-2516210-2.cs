            ObservableCollection<EmployeeView> observableEmployees = 
                        new ObservableCollection<EmployeeView>();
            foreach (Employee emp in employeesToObserve)
            {
                observableEmployees.Add(new EmployeeView(emp));
            }
            observableEmployees.CollectionChanged += 
                (object sender, NotifyCollectionChangedEventArgs e) =>
                {
                    ObservableCollection<EmployeeView> views = 
                            sender as ObservableCollection<EmployeeView>;
                    if (views == null)
                        return;
                    switch (e.Action)
                    {
                         case NotifyCollectionChangedAction.Add:
                            foreach (EmployeeView view in e.NewItems)
                            {
                                if (!employeesToObserve.Contains(view.Employee))
                                    employeesToObserve.Add(view.Employee);
                            }
                            break;
                         case NotifyCollectionChangedAction.Remove:
                            foreach (EmployeeView view in e.OldItems)
                            {
                                if (employeesToObserve.Contains(view.Employee))
                                    employeesToObserve.Remove(view.Employee);
                            }
                            break;
                        default:
                            break;
                    }
                };
