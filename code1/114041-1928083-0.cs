    public IEnumerable<int> GetNumbers(string fileName)
    {
        using (StreamReader sr = File.OpenText(fileName))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                foreach (string item in Regex.Split(line, @"\D+"))
                {
                    yield return int.Parse(item);
                }
            }
        }
    }
