    public class Answer 
    { 
        public string Answers { get; set; } 
        static public implicit operator Answer(string input)
        {
            var a = new Answer();
            a.Answers = input;
            return a;
        }
    } 
    
