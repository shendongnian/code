    Packet packet = new LoginPacket
    {
        Username = "User",
        Password = "user",
        Status = 123
    };
    Console.WriteLine("{0}=={1}",
        packet["Username"],
        ((LoginPacket)packet).Username);
