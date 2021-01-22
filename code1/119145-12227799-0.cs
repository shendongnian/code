    <pre>it may help in some scenario 
    StreamReader reader = new StreamReader(file);    
    string _Line = reader.ReadToEnd();
    string IntMediateLine = string.Empty;
    IntMediateLine = _Line.Replace("entersign", "");
    string[] ArrayLineSpliter = IntMediateLine.Split('any specail chaarater');</pre>
