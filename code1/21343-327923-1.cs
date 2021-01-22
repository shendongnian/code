    public static string[] ToGrade(double[] grades)
    {
      // sanity checks go here
      string[] result = new string[grades.Length];
      for(int i = 0; i < grades.Length; i++)
        result[i] = ToGrade(grades[i]);
      return result;
    }
