    public class Student
    {
    	public int? StudentId { get; set; }
    	public string StudentName { get; set; }
    	private int? _attendanceStatusId;
    	public int AttendanceStatusId
    	{
    		//you can use null coalescing operator here
    		//like this: get { return _attendanceStatusId ?? 1 }
    		get { return _attendanceStatusId == null ? 1 : _attendanceStatusId.Value; }
    		set { _attendanceStatusId = value; }
    	}
    	private string _attendanceStatusDes;
    	public string AttendanceStatusDes
    	{
    		//Or get { return _attendanceStatusDes ?? "Present" }
    		get { return _attendanceStatusDes == null ? "Present" : _attendanceStatusDes; }
    		set { _attendanceStatusDes = value; }
    	}
    }
