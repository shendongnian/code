    for (int i = 0; i < botsnumber; i++)
    {
        //Here generate bots: Bot b1 = new Bot(); Bot b2 = new Bot(); 
        Bot b = new Bot(); 
        b.say();
    }
    
    // or
    var bots = new List<Bot>();
    for (int i = 0; i < botsnumber; i++)
    {
        //Here generate bots: Bot b1 = new Bot(); Bot b2 = new Bot(); 
        bots.Add(new Bot());
    }
    foreach (var bot in bots)
    {
        bot.say();
    }
