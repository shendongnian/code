    foreach(string a in source.split('\n'))
    {
    if(a.StartsWith("print "))
    {
    Console.WriteLine(a.Substring(6));
    }
    if(a == "stop")
    {
    Console.ReadLine();
    }
