    public void addNewVariableAssignment()
    {
        newVariableAssignment = new VariableAssignment();
        newVariableAssignment.IdVariable = //adding values
        context.VariableAssignments.Add(newVariableAssignment); 
    
        context.SaveChanges(); 
        VariableAssignments.Add(newVariableAssignment);
    }
