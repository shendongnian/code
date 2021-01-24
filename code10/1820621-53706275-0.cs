    var output = @"C:\TEMP\target.csv";
    string so = System.IO.File.ReadAllText(output);
     
    Console.WriteLine("without replace");
    Console.Write(so);
    Console.WriteLine("");
    Console.WriteLine("with replace");
    Console.Write(so.Replace("\n", "").Replace("\r", ""));
    Console.ReadLine();
