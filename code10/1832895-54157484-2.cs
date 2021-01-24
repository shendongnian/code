    Console.WriteLine("Enter a user (case sensitive)");
    var userName = Console.ReadLine();
    
    var user = _users.FirstOrDefault(x => x.UserName == userName);
    
    if (user != null)
    {
       Console.WriteLine(user.FavoriteColor);
    }
    else
    {
       Console.WriteLine("Game over, you failed");
    }
    Console.ReadLine();
