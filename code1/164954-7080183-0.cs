    LocalMessageBus.AddMessage(<MessageKey>,<MessageActualContentAsObject>);
    dialogController.ShowDialog(<TargetViewName_SayEmployeeList>);
    Employee selectedEmployee = LocalMessageBus.GetMessage(<MessageKey>) as Employee;
    if (selectedEmployee != null)
    {
    //doSomework with selected employee
    }
