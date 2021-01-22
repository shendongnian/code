	public Student GetById(int id)
	{
		// Calls context.ObjectSet<T>().SingleOrDefault(predicate) 
		// on my generic EntityRepository<T> class 
		return SingleOrDefault(student =>  
			student.Active && 
			student.Id == id);
	}
