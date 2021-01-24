    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;
    
    namespace OneWayTwoWayBinding
    {
        public class EmployeeViewModel : Employee
        {
            public EmployeeViewModel()
            {
    
                ObservableCollection<Employee> Employees = new ObservableCollection<Employee>()
                {
                    new Employee{EmployeeName = "Adrian",EmployeeID = "1",EmployeeSalary = 15000,EmployeeDesigner = "SoftwareEngingeer12312", EmployeeEmailID = "drozd001@gmail423423.com"},
                    new Employee{EmployeeName = "Bartek",EmployeeID = "2",EmployeeSalary = 15000,EmployeeDesigner = "SoftwareEngingeer",EmployeeEmailID = "drozd001@gmail.com"},
                    new Employee{EmployeeName = "Czarek",EmployeeID = "3",EmployeeSalary = 30000,EmployeeDesigner = "SoftwareEngingeer",EmployeeEmailID = "drozd001@gmail.com"}
                };
    
                FilteredCollection = CollectionViewSource.GetDefaultView(Employees);
    
                //SelectedEmployee = new Employee {EmployeeName = string.Empty, EmployeeID = string.Empty, EmployeeSalary = string.Empty, EmployeeDesigner = string.Empty, EmployeeEmailID = string.Empty};
    
                //EmployeeDesigner = "SoftwareEngingeer12312";
                //EmployeeDesigner = "SoftwareEngingeer12312";
                //DynamicSearch.EmployeeName = "Czarek";
                //EmployeeSalary = 10;
                ChangedPathBinding = -1;
                SelectedEmployee = null;
            }
    
            RelayCommand _saveCommand;
            public ICommand SaveCommand
            {
                get
                {
                    if (_saveCommand == null)
                    {
                        _saveCommand = new RelayCommand((param) => this.Save(param),
                            param => this.CanSave);
                    }
                    return _saveCommand;
                }
            }
    
            public void Save(object parameter)
            {
                string[] SearchedCollection = ((string)parameter).Split(new char[] { ':' });
                SelectedEmployee.EmployeeName = SearchedCollection[0];
                //FilteredCollection.Filter = null;
                SelectedEmployee = null;
                //EmployeeName = null;
                //EmployeeSalary = null;
            }
    
    
            bool CanSave
            {
                get
                {
                    return true;
                }
            }
        }
    
    }
