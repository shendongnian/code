    public void SortStudents(Func<string, string, int> compareFunction) 
    {
        string temp;
        for (int i = 0; i < students.Count; i++)
        {
            for (int j = i + 1; j < students.Count; j++)
            {
                if (compareFunction(students[i], students[j]) > 0)
                {
                    temp = students[j];
                    students[j] = students[i];
                    students[i] = temp;
                }
            }
            Console.WriteLine(students[i]);
        }
    }
    SortStudents(string.Compare); // sorts students alphabetically
    SortStudents((a, b) => a.Length.CompareTo(b.Length)); // sorts students by the length of their names
