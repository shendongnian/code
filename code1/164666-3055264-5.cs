    LoginPacket packet = new LoginPacket
    {
        Username = "User",
        Password = "user",
        Status = 123
    };
    Console.WriteLine(packet.Username); // Is equal to:
    Console.WriteLine(packet["Username"]);
