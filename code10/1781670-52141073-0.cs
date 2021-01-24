    var questions = new List<string> { "hi", "weird", "by" };
    var tester = new Dictionary<int, List<string>>();
    
    // Use this for initialization
    void Start () 
    {     
        tester.Add(1, questions);
        tester.Add(2, new List<string> { "hello" });
        tester.Add(3, new List<string> { "by" });
        tester.Add(4, new List<string> { "hi" });
        tester.Add(5, new List<string> { "bye" });
    }
    public void hello ()
    {
        if(tester.ContainsKey(2))
        {
            var answers = tester[2] ?? new List<string>();
            // now you have all answers linked to question with id 2 in answers variable
        }
    }
