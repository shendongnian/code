    DateTime d = DateTime.Now;
    DateTime c = DateTime.Now;
    c = d.AddDays(145);
    string cc ;
    Console.WriteLine(d);
    Console.WriteLine(c);
    var t = (c - d).Days;
    Console.WriteLine(t);
    cc = Console.ReadLine();
