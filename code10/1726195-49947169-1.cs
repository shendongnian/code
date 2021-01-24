    try
    {
        string input = System.IO.File.ReadAllText("path");
        string output = System.Text.RegularExpressions.Regex.Replace(input, @"^\s+$[\r\n]*", "", System.Text.RegularExpressions.RegexOptions.Multiline);
        System.IO.File.WriteAllText("path", output);
    }
    catch (Exception e)
    {
        //Log..
        Dts.TaskResult = (int)ScriptResults.Failure;
    }
