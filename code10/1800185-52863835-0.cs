    string Print1(string message)
    {
        print(message);
        return message;
    }
    void Print2(string message)
    {
        var msg = Print1(message);
        print(msg);
    }
