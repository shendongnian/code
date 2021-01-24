    //This is your class for a single question.  A list of these will 
    //make up a paper.
    public class Genes
    {
        public string Question{ get; set; }
        public int CLO { get; set; }
    }
    
    //This is a Paper, which contains a list of Questions.
    public class Paper
    {
        public List<Genes> Questions { get; set; }
    }
    ..
    ..
    //To use:  First create a list of papers - 
    //this is a stack of papers.
    List<Paper> stackOfPapers = new List<Paper>();
    //now create a list of questions which we can add to a paper
    List<Genes> questions = new List<Genes>();
    //Now we need to create a question to add to the list of questions.
    Genes newQuestion = new Genes();    
    newQuestion.Question = "How many roads must a man walk down?";
    newQuestion.CLO = 42;
    
    //now add the question to the list.
    questions.Add(newQuestion);
    
    //now we need to create a paper.  This will represent one
    //paper in our stack of papers.
    Paper newPaper = new Paper();
    //add our list of Questions to the paper.
    newPaper.Questions = questions;
    //and finally, add the paper to the stack of papers.
    stackOfPapers.Add(newPaper);
    
    //or alternatively, you can use the object initializer syntax to 
    //do this all in one.  Note I've also added more than one paper to 
    //the list of papers, and each paper has two questions contained in it:    
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
