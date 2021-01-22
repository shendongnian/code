public class Employee
{ 
  //first name
  //last name
  //is manager
  //is teamleader
  //address
}
public interface IEmployeeView
{ 
  void SetEmployee(Employee employee);
}
public partial class EmployeeForm:WinForm,IEmployeeView
{
  public void SetEmployee(Employee employee)
  {
    ENameTextBox.Text = employee.FirstName+" "+employee.LastName;
  } 
}
