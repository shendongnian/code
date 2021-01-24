	public class FaceDetect
	{
		public int age { get; set; }
		public int beauty { get; set; }
		public int expression { get; set; }
		public int gender { get; set; }
		public bool glass { get; set; }
		public int smile { get; set; }
	}
	public class FaceRecg
	{
		public int confidence { get; set; }
		public string name { get; set; }
		public string person_id { get; set; }
	}
	public class FaceList
	{
		public FaceDetect face_detect { get; set; }
		public FaceRecg face_recg { get; set; }
	}
	public class CustomerNTF
	{
		public List<FaceList> face_list { get; set; }
		public int face_num { get; set; }
		public string msg_id { get; set; }
	}
