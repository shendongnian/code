    string dirReg = "_TestData$";
    
    foreach (string subDir in Directory.GetDirectories(target))
    {
      if (Regex.IsMatch(subDir, dirReg))
           Console.WriteLine("success");
      else
           Console.WriteLine("fail");                       
    }
