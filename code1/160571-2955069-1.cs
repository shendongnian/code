    // This would come from Stream.ReadLine() or something
    string line = "02/06/2010,10:05,1.0,2.0,3.0,4.0,5";
    
    string[] parts = line.Split(',');
    DateTime date = DateTime.ParseExact(parts[0], "dd/MM/yyyy", null);
    TimeSpan time = TimeSpan.Parse(parts[1]);
    date = date.Add(time); // adds the time to the date
    float float1 = Single.Parse(parts[2]);
    float float2 = Single.Parse(parts[3]);
    float float3 = Single.Parse(parts[4]);
    float float4 = Single.Parse(parts[5]);
    int integer = Int32.Parse(parts[6]);
    Console.WriteLine("Date: {0:d}", date);
    Console.WriteLine("Time: {0:t}", date);
    Console.WriteLine("Float1: {0}", float1);
    Console.WriteLine("Float2: {0}", float2);
    Console.WriteLine("Float3: {0}", float3);
    Console.WriteLine("Float4: {0}", float4);
    Console.WriteLine("Integer: {0}", integer);
