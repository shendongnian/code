    foreach (var technician in projectTechnicians)
        {
            EmpGuid.Add(technician.EmpGuid);
        }
        parameters = ToDataTable(EmpGuid);
    
        foreach (var teamLeader in teamLeaders)
        {
            EmpGuid.Add(teamLeader.EmpGuid);
        }
        parameters = ToDataTable(EmpGuid); // Overwriting projectTechnicians added above.
