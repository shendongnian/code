    List<int> integers = new List<int>();
    foreach (string line in File.ReadAllLines(path))
    {
        foreach (string item in line.Split(' '))
        {
            int i;
            if (!int.TryParse(item, out i))
            {
                throw new Exception("Implement error handling here");
            }
            integers.Add(i);
        }
    }
