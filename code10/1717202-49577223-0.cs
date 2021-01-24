    static void SaveAllStudentsToFile(string fileName, Student[] group)
    {
        // create a place to hold data
        string[] data = new string[group.Length];
        int counter = 0;
        for (int i = 0; i < group.Length; i++)
        {
            data[i] = group[i].ToString();
        }
        // now write the data to a file
        File.WriteAllLines(fileName, data);
    }
