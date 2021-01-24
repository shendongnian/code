    public void read()
    {
        string[] textes = File.ReadAllLines(@"C:\Users\sashk\Source\Repos\ConsoleApp6\ConsoleApp6\save.txt", Encoding.Default);
        List<string> texts = new List<string>();
        for (int i = 0; i < textes.Lenght; i++)
        {
            texts.Add(textes[i].Replace(" Name: ", ""));
            texts.Add(textes[i].Replace(" FacultyNumber: ", ""));
            texts.Add(textes[i].Replace(" Grades: ", ""));
            texts.Add(textes[i].Replace(" AverageGrade: ", ""));
        }
        foreach (string text in texts)
        {
            Debug.WriteLine(text);
        }
    }
