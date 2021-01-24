    private readonly Dictionary<(bool isMsgValid, bool isScoreValid, bool isAgeValid), string> _responses 
        = new Dictionary<(bool, bool, bool), string>()
    {
        [(true, true, true)] = "All para success",
        // and so on
    };
    public string checkIfConnditions(string msg, int score, int age)
        => _responses[(msg == "hello", score > 20, age < 25)];
