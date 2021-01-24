              public void OnSelectionChanged(object parameter)
              {
                if(SelectedEmployee == null)
                {
                    IndexesOfSelectedEmployees.Clear();
                }
                if(SelectedEmployee != null)
                {
                    foreach (Employee item in Employees)
                    {
                        if (item.IsSelected == true)
                        {
                            IndexesOfSelectedEmployees.Add(SelectedIndex.GetValueOrDefault());
                        }
                    }
                    foreach (int itemIndexesOfSelectedEmployees in IndexesOfSelectedEmployees)
                    {
                        foreach (Employee itemEmployees in Employees)
                        {
                            if (itemIndexesOfSelectedEmployees == Employees.IndexOf(itemEmployees))
                            {
                                itemEmployees.IsSelected = true;
                            }
                        }
                    }
              }
