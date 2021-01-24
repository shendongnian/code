    string a = "0";
    string b = "-15";
    DateTime d = DateTime.Now;
    DateTime e = d.AddDays(int.Parse(a));
    if (e == d)
    {
        Console.WriteLine("{0} does equal {1}!", e, d);
    }
    Console.ReadLine();
