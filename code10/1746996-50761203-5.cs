    using (var sw = new StreamWriter("output.csv"))
    {
        for (int i = 0; i < _flagImageSources.Length; i++)
        {
          string str = _flagImageSources[i];
          string outputText = str.Substring(68, 3);
          sw.WriteLine(outputText);
        }   
    }
