    public class Student
    {            
        public int? StudentId { get; set; }
        public string StudentName { get; set; }
        private int? _attendanceStatusId;
        public int AttendanceStatusId 
        { 
           //you can use null coalescing operator here
           //like this: get { _attendanceStatusId ?? 1 }
           get { _attendanceStatusId == null ? 1 : _attendanceStatusId; }
           set {  _attendanceStatusId = value; }
         }
        private string _attendanceStatusDes;
        public string AttendanceStatusDes 
        { 
           //Or get { _attendanceStatusDes ?? "Present" }
           get { _attendanceStatusDes == null ? "Present" : _attendanceStatusDes; }
           set {  _attendanceStatusDes = value; }
         } 
    }
