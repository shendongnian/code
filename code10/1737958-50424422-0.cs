    public class Student
    {
        private ArrayList grades;
     	public Student()
	    {
            grades = new ArrayList();
	    }
        public void addGrade(double val)
        {
            grades.Add(val);
        }
        public double getAverage()
        {
            double avg = 0;
            for (int i = 0; i < grades.Count; i++)
                avg += (double)grades[i];
            avg /= grades.Count;
            return avg;
        }
    }
