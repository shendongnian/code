    public class Question
    {
        public string Text {get; set; }
        public List<Answer> Answers {get; set; } 
    
  
         public Question(){
         Answers=new List<Answer>();
        }
    }
