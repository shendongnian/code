        [Output][1]
        string[] files = Directory.GetFiles(@"D:\test\", "*.txt");
		List<string> data = new List<string>();
        foreach (string file in files)
        {
            using (StreamReader sr = File.OpenText(file))
            {
                 string fileContent = sr.ReadToEnd();   
                 data.Add(fileContent);
            }
        }
  
