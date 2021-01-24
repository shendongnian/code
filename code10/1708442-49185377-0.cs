     class Student {
           string Name { get; private set; }
           int[] Assignments { get; set; }
           char Grade { get { return Assignments.Sum() > 300 ? 'P' : 'F'; } }
           public string AssignmentsStr
           {get{return string.join(",",Assignments);}}
        }
