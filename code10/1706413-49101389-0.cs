    List<string> playerOneHands = new List<string>();
    List<string> playerTwoHands = new List<string>();
    foreach (string line in lines)
    {
        playerOneHands.Add(line.Substring(0, 14));
        playerTwoHands.Add(line.Substring(15, 14));
    }
