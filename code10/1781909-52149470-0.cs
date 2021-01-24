    botsnumber = Int32.Parse(Console.ReadLine());
    var list = new List<Bot>();
    for (int i = 0; i < botsnumber; i++)
    {
       Bot b = new Bot(); 
       list.Add(b);
    }
    list.ForEach(b => b.say());
