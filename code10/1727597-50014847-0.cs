    var resultPath = GetFilePath();
    String[] lines = null;
    lines = System.IO.File.ReadAllLines(resultPath);
    var listSeparator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
    string[] values = lines[result.LineNumber - 1].Split(new String[] { listSeparator }, StringSplitOptions.None); 
