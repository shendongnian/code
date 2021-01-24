    using (var sw = new StreamWriter("output.csv"))
    {
        string str;
        string outputText;
        for (int i = 0; i < _flagImageSources.Length; i++)
        {
          str = _flagImageSources[i];
          outputText = str.Substring(68, 3);
          sw.WriteLine(outputText);
        }   
    }
