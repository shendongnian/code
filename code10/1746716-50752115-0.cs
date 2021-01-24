    var lines = File.ReadAllLines(filename);
    foreach (var line in lines)
    {
         string[] word = line.Split('\t');
         for (int i = 0; i <= word.Length; i++)
         {    
              ec.code = Convert.ToInt32(word[0]);
              ec.Name = word[1];
              ec.Number = Convert.ToInt32(word[2]);
              ec.City = word[3];
              list.Add(ec);
         }
    }
