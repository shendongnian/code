    var selectedStaff = new Staff();
    selectedStaff.Id = 2;
    context.Staff.Attach(selectedStaff); // The important part.
    
    var todo = new ToDo    
    {    
        ID = ToDoID,    
        Staff = selectedStaff,
        Priority = ddlPriority.SelectedValue,    
        TaskName = txtTaskName.Text.Trim(),
        Notes = txtNotes.Text.Trim(),
        ....
    }
    
    context.SaveChanges();
