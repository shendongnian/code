	public class Student
	{
		public int ID { get; set; }
		public virtual ICollection<StudentRecord> StudentRecords { get; set; }
	}
					
	public class StudentRecord
	{
		public int ID { get; set; }
		public int StudentID { get; set; }
		public virtual Student Student { get; set; }
	}
