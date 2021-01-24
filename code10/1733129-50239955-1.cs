	public static CreateStudents(params string[] names)
	{
		List<Student> students = new List<Student>();
		foreach (stName in Names)
		{
			students.Add(new Student(stName));
		}
		return students;
	}
