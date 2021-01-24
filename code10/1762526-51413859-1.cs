    private Random rnd = new Random();
    
    public int rand_num()
    {
        string exe_path = System.Windows.Forms.Application.ExecutablePath;
        string exe_folder = System.IO.Path.GetDirectoryName(exe_path);
        string file_path = System.IO.Path.Combine(exe_folder, "Invoices\numbers.txt");
    
        string[] commaSeparatedValues = Regex.Split(System.IO.File.ReadAllText(file_path), "[^0-9]+");
        IEnumerable<int> usedValues = commaSeparatedValues.Select(x => int.Parse(x)).AsEnumerable();
        int[] availableValues = Enumerable.Range(0, 9999).Except(usedValues).ToArray();
        int number = availableValues[rnd.Next(0, availableValues.Count())];
    
        File.WriteAllText(file_path, commaSeparatedValues + "," + number);
    
        return number;
    }
