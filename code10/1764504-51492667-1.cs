    public class Student
    {            
        public int? StudentId { get; set; }
        public string StudentName { get; set; }
        private int? _attendanceStatusId;
        public int AttendanceStatusId 
        { 
           get { _attendanceStatusId == null ? 1 : _attendanceStatusId; }
           set {  _attendanceStatusId = value; }
         }
        private string _attendanceStatusDes;
        public string AttendanceStatusDes 
        { 
           get { _attendanceStatusDes == null ? "Present" : _attendanceStatusDes; }
           set {  _attendanceStatusDes = value; }
         } 
    }
