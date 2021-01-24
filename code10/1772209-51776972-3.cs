    // add EmpGuids from lstTech if no check box is selected.
    // you need to add all checkboxes not selected in the condition
    if (!chkProjectTechs.Checked && !chkTeamLeader.Checked)
    {
        foreach (DataRowView list in lstTech.SelectedItems)
        {
            var selectedEmpGuid = (Guid)list[0];
            EmpGuid.Add(selectedEmpGuid);
        }
    }
    // if projectTechnicians is checked, then add projectTechnicians EmpGuids to parameters
    if (chkProjectTechs.Checked)
    {
        foreach (var technician in projectTechnicians)
        {
            EmpGuid.Add(technician.EmpGuid);
        }
    }
    
    // add team leader Empguids if checked.
    if (chkTeamLeader.Checked)
    {
        foreach (var teamLeader in teamLeaders)
        {
            EmpGuid.Add(teamLeader.EmpGuid);
        }
    }
    
    // Add new checkbox conditions here
    //
    // perform your next operation on parameters here. 
    // At this point you will have either lstTech employees or employees based on checkbox selection in EmpGuid list.
    parameters = ToDataTable(EmpGuid);
