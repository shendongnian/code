    ...
    double average = CalculateAverage(grades);
    ...
    private double CalculateAverage(double[] grades)
    {
        double sum = 0;
        int numberOfGrades = 0;
        for (int i = 0; i < grades.Length; i++)
        {
            if (grades[i] == 0)
                continue;
            sum += grades[i];
            numberOfGrades++;
        }
        return sum / numberOfGrades;
    }
