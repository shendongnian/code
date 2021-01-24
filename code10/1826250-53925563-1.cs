    static IfxCommand GetStudents() { //create unfiltered query here ... }
    
    static IfxCommand FilterByCampus(
        this IfxCommand command,
        int campusId) 
    { 
        if (campusId != 0)
        {
            command.CommandText += " AND camp_code = ?";
            myIfxCmd.Parameters.Add(...);
        }
        return command;   
    }
    static IfxCommand FilterByYears(
        this IfxCommand command,
        DateTime start,
        DateTime end) { ... }
      //etc.
