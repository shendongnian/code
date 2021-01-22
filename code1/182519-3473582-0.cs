    void Method1(Dictionary<string, string> dict) {
        dict["a"] = "b";
        dict = new Dictionary<string, string>();
    }
    void Method2(ref Dictionary<string, string> dict) {
        dict["e"] = "f";
        dict = new Dictionary<string, string>();
    }
    public void Main() {
        var myDict = new Dictionary<string, string>();
        myDict["c"] = "d";
        Method1(myDict);
        Console.Write(myDict["a"]); // b
        Console.Write(myDict["c"]); // d
        Method2(ref myDict); // replaced with new blank dictionary
        Console.Write(myDict["a"]); // key runtime error
        Console.Write(myDict["e"]); // key runtime error
    }
