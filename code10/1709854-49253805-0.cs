    public class Genes
    {
        public string Question{ get; set; }
        public int CLO { get; set; }
    }
    
    public class Paper
    {
        public List<Genes> Questions { get; set; }
    }
    ..
    ..
    List<Paper> stackOfPapers = new List<Paper>();
    List<Genes> questions = new List<Genes>();
    Genes newQuestion = new Genes();
    newQuestion.Question = "How many roads must a man walk down?";
    newQuestion.CLO = 42;
    questions.Add(newQuestion);
    Paper newPaper = new Paper();
    newPaper.Questions = questions;
    stackOfPapers.Add(newPaper);
    
    //or alternatively:
    
    var newStackOfPapers = 
        new List<Paper>
        {
            new Paper
            {
                Questions = new List<Genes> {
                    new Genes
                    {
                        Question = "How many roads must a man walk down?",
                        CLO = 42
                    },
                    new Genes
                    {
                        Question = "Another Question?",
                        CLO = 111
                    }
                }
            },
            //add Another paper...
            new Paper
            {
                Questions = new List<Genes> {
                    new Genes
                    {
                        Question = "This is the first question on the second paper?",
                        CLO = 22
                    },
                    new Genes
                    {
                        Question = "Another Question?",
                        CLO = 33
                    }
                }
            },
        };
