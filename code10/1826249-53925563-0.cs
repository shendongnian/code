    static IfxCommand GetStudents() { //create unfiltered query here ... }
    static IfxCommand FilterByYears(
        this IfxCommand command,
        DateTime start,
        DateTime end) { ... }
     static IfxCommand FilterByCampus(
         this IfxCommand command,
         int campusId) { ... }
      //etc.
