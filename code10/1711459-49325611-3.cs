	public class Course {
		public string CourseCode { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int NoOfEvaluations { get; set; }
	}
	
	List<Course> courses = new List<Course>();
	bool CourseAlreadyExists(Course course) { 
		foreach (Course c in courses) { 
			if (c.CourseCode == course.CourseCode) {
				return true;
			}	 
		} 
		
		return false; 
	} 
	
	// Define other methods and classes here
	public void ImportCourses(string fileName, char Delim) {
		using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read)) {
			using (var reader = new StreamReader(stream)) {
				int index = 0;
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var array = line.Split(Delim);
					if (array.Length != 4)
					{
						throw new ApplicationException(String.Format("Invalid number of fields in record #{0}", index));
					}
				
					Course C = new Course();
					C.CourseCode = array[0];
					C.Name = array[1];
					C.Description = array[2];
			
					int evals;
					if (!int.TryParse(array[3], out evals))
					{
						throw new ApplicationException(String.Format("Number of evaluations in record {0} is not in correct format.", index));
					}
					else
					{
						C.NoOfEvaluations = evals;
					}
			
					if (!CourseAlreadyExists(C))
					{
						courses[index++] = C;
					}
					else
					{
						throw new ApplicationException(String.Format("Course code in record {0} is in use", index));
					}
				}
			}
		}
	}
}
