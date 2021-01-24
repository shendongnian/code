    public class StudentEntity {
    	public string studentId { get; set; }
    	public string studentStatus { get; set; }
    	public DateTime studentStatusChanged { get; set; }
    	
    	public void SetStudentStatus(string status) {
    		studentStatus = status;	
    		studentStatusChanged = DateTime.Now;
    	}
    } 
  
