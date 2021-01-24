    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Windows;
    using System.Collections.ObjectModel;
    using System.Windows.Data;
    using System.Windows.Threading;
    
    namespace OneWayTwoWayBinding
    {
        public class Employee : INotifyPropertyChanged
        {
            private string employeeName;
            private string employeeID;
            private int? employeeSalary;
            private string employeeDesigner;
            private string employeeEmailID;
            private Employee selectedEmployee;
            private ICollectionView filteredCollection;
            private string dynamicSearch;
            private int changedPathBinding;
            public string EmployeeName
            {
                get
                {
                    return employeeName;
                }
                set
                {
                        employeeName = value;
                        if (FilteredCollection != null)
                            FilteredCollection.Filter = x => (String.IsNullOrEmpty(employeeName) || ((Employee)x).EmployeeName.Contains(employeeName));
                        OnPropertyChanged("EmployeeName");
                }
            }
            public string EmployeeID
            {
                get
                {
                    return employeeID;
                }
                set
                {
                    employeeID = value;
                    OnPropertyChanged("EmployeeID");
                }
            }
            public int? EmployeeSalary
            {
                get
                {
                    return employeeSalary;
                }
                set
                {
                    employeeSalary = value;
                    OnPropertyChanged("EmployeeSalary");
                    if (FilteredCollection != null)
                        FilteredCollection.Filter = x => ((employeeSalary == null) || ((Employee)x).EmployeeSalary == employeeSalary);
                }
            }
            public string EmployeeDesigner
            {
                get
                {
                    //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(employeeDesigner)));
                    return employeeDesigner;
                }
                set
                {
                    employeeDesigner = value;
                    OnPropertyChanged("EmployeeDesigner");
                    if (FilteredCollection != null)
                    FilteredCollection.Filter = x => (String.IsNullOrEmpty(employeeDesigner) || ((Employee)x).EmployeeDesigner.Contains(employeeDesigner));
                }
            }
            public string EmployeeEmailID
            {
                get
                {
                    return employeeEmailID;
                }
                set
                {
                    employeeEmailID = value;
                    OnPropertyChanged("EmployeeEmailID");
                }
            }
            public IList<Employee> EmployeeList
            {
                get; set;
            }
    
            public Employee SelectedEmployee
            {
                get
                {
                    //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(selectedEmployee.SelectedEmployee.ToString())));
                    return selectedEmployee;
                }
                set
                {
                    selectedEmployee = value;
                    OnPropertyChanged("SelectedEmployee");
                }
            }
    
            public string DynamicSearch
            {
                get
                {
                    if (SelectedEmployee == null)
                    {
                        EmployeeName = dynamicSearch;
                    }
                    return dynamicSearch;
                }
                set
                {
                        dynamicSearch = value;
                        OnPropertyChanged("DynamicSearch");
                }
            }
            public ICollectionView FilteredCollection
            {
                get
                {
                    return filteredCollection;
                }
                set
                {
                    filteredCollection = value;
                    OnPropertyChanged("FilteredCollection");
                }
            }
    
            public int ChangedPathBinding
            {
                get
                {
                    //Application.Current.Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(changedPathBinding.ToString())));
                    return changedPathBinding;
                }
                set
                {
                    changedPathBinding = value;
                    OnPropertyChanged("ChangedPathBinding");
                    //SelectedEmployee.EmployeeName
                }
            }
    
            public ObservableCollection<Employee> Employees { get; private set; }
    
            public event PropertyChangedEventHandler PropertyChanged = null;
            virtual protected void OnPropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
