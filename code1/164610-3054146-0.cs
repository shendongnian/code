    using (StreamWriter Tex = new StreamWriter("C:/temp/Arungg.txt", true, Encoding.UTF8))
    {
        Tex.WriteLine("Test1");
        Tex.WriteLine("Test2");
        Tex.Write(Tex.NewLine);
        Console.WriteLine(" The Text file named Arungg is created ");
    } 
