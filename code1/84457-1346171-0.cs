<blockquote><pre>class EmployeeForm : UserControl
{
    EmployeeObject employee;
    // ...
    void employeeNameTextBox_Validating (object sender, CancelEventArgs e)
    {
        if ( employee.Name.Trim ().Length == 0 ) {
            errorProvider.SetError (employeeNameTextBox, "Employee must have a name");
            e.Cancel = true;
        }
    }
    void employeeHireDateControl_Validating (...)
    {
        if ( employee.HireDate &lt; employee.BirthDate ) {
            errorProvider.SetError (employeeHireDateControl, 
                "Employee hire date must be after birth date");
            e.Cancel = true;
        }
    }
}
class ExplorerStyleInterface : ... 
{
    // ...
    bool TryDisplayNewForm (Form oldForm, Form newForm)
    {
        if ( ! oldForm.ValidateChildren () )
            return false;
        else {
            HideForm (oldForm);
            ShowForm (newForm);
            return true;
        }
    }
}</pre></blockquote>
    
