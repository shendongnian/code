    public class QandA {
        public string Question;
        public string Answer;
    }
    
    Dictionary<string, List<QandA> > Trivia;
    
    public InitTrivia() {
        Trivia = new Dictionary<string, List<QandA>>();
    
        Trivia.Add( "Algebra", new List<QandA> {
            new QandA { Question = "What is 2 + 2?", Answer = "Four" },
            new QandA { Question = "What is 6 x 3?", Answer = "Eighteen" },
        });
    }
