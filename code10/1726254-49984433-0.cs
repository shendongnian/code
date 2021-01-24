    public class StudentEntity {
		private string _studentStatus;
		public string studentId { get; set; }
		public string studentStatus
		{
			get { return _studentStatus; }
			set {
				_studentStatus = value;
				studentStatusChanged = DateTime.Now;
			}
		}
		public DateTime studentStatusChanged { get; set; }
	}
