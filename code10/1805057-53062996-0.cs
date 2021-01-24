    var text = null;
    using (StreamReader sr = new StreamReader(e.FullPath))
    {
        text = sr.ReadToEnd();
        Console.WriteLine(text);
    }
    
    using (StreamWriter sw = new StreamWriter(e.FullPath))
    {
        var replaced = text.Replace("The words I want to replace", "text I want it to be replaced with");
        sw.Write(replaced);
    }
