    public enum Question
    {
      Age,
      Name
    }
    
    ...
    
    Dictionary<Question,string> Questions = new Dictionary<Question,string>();
    
    Questions.Add(Question.Age,  "How old are you ?");
    Questions.Add(Question.Name, "What is your name ?");
