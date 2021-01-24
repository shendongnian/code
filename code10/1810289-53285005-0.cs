    var asd = Enumerable.Range(0, 1000000).ToList();
    
    var sw1 = new Stopwatch();
    sw1.Start();
    Console.WriteLine(string.Concat(asd.Select((x, i) => (i + 1) % 3 != 0 ? x + " " : x + Environment.NewLine)));
    sw1.Stop();
    
    var sw2 = new Stopwatch();
    sw2.Start();
    
    var sb1 = new StringBuilder();
    for (int i = 0; i < asd.Count; i += 3)
        sb1.AppendLine(string.Join(" ", asd.Skip(i).Take(3)));
    Console.WriteLine(sb1.ToString());
    
    sw2.Stop();
    
    var sw3 = new Stopwatch();
    sw3.Start();
    
    var sb2 = new StringBuilder();
    int counter = 0;
    string output = "";
    foreach (int value in asd)
    {
        counter++;
        if (counter % 3 == 0)
        {
            output += value;
            sb2.AppendLine(output);
            output = string.Empty;
        }
        else
            output += value + " ";
    }
    Console.WriteLine(sb2.ToString());
    sw3.Stop();
    
    var sw4 = new Stopwatch();
    sw4.Start();
    
    var sb3 = new StringBuilder();
    for (int i = 0; i <asd.Count / 3; i++)
    {
        int index = i * 3;
        sb3.AppendFormat("{0} {1} {2}", asd[index], asd[index + 1], asd[index + 2]);
        sb3.AppendLine();
    }
    Console.WriteLine(sb3.ToString());
    sw4.Stop();
    
    Console.WriteLine("MySolution: " + sw1.ElapsedMilliseconds);
    Console.WriteLine("Mong Zhu's Solution: " + sw2.ElapsedMilliseconds);
    Console.WriteLine("Wojtek's Solution: " + sw3.ElapsedMilliseconds);
    Console.WriteLine("Nirmal Subedi's Solution: " + sw4.ElapsedMilliseconds);
    
    Console.ReadKey();
