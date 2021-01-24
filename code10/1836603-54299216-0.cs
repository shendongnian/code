    public void SortStudents(IComparer<string> comparer) // sort students using selection sort
    {
        string temp;
        for (int i = 0; i < students.Count; i++)
        {
            for (int j = i + 1; j < students.Count; j++)
            {
                if (comparer.Compare(students[i], students[j]) > 0) // use given comparer instead.
                {
                    temp = students[j];
                    students[j] = students[i];
                    students[i] = temp;
                }
            }
            Console.WriteLine(students[i]);
        }
    }
