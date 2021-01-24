    public class Quiz
    {
        public static void Main()
        {
            
            Quizard QuizGame = new Quizard();
            QuizGame.Questions.Add(new QuestionObject {
                Question = "The fuselage is the center structure of an aircraft and provides the connection for the wings and tail?",
                Options = new List<string> { "True", "False" },
                CorrectAnswer = "a"
            });
            QuizGame.Questions.Add(new QuestionObject {
                Question = "Rolling is the action on the lateral axis of an aircraft?",
                Options = new List<string> { "True", "False" },
                CorrectAnswer = "a"
            });
            QuizGame.Questions.Add(new QuestionObject {
                Question = "Which of the following are part of an aircraft primary flight controls?",
                Options = new List<string> { "Primary Bus", "Avionics Bus", "Battery", "GPU (ground power unit)" },
                CorrectAnswer = "d"
            });
            QuizGame.Questions.Add(new QuestionObject {
                Question = "The Fuel-air control unit of a reciprocating engine?",
                Options = new List<string> { "Sends fuel to the piston chamber", "Sends air to the piston chamber", "Controls the mixture of air and fuel", "Meters the quantity of fuel" },
                CorrectAnswer = "c"
            });
            Display(QuizGame.Questions);
            while (true) {
                if (QuizGame.Questions.Where(x => x.Correct == false) != null) {
                    Console.WriteLine(QuizGame.Questions.Where(x => x.Correct == true).Count() + " out of " + QuizGame.Questions.Count);
                    Console.WriteLine("Would you like to try again? Y/N");
                    if (Console.ReadLine().ToLower() == "y") {
                        Display(QuizGame.Questions.Where(x => x.Correct == false).ToList());
                    } else {
                        break;
                    }
                } else {
                    break;
                }
            }
            void Display(List<QuestionObject> questions)
            {
                string[] marker = new string[] { "A", "B", "C", "D" };
                foreach (var question in questions) {
                    Console.WriteLine(question.Question);
                    for (int i = 0; i < question.Options.Count; i++) {
                        Console.WriteLine($"{marker[i]}. {question.Options[i]}");
                    }
                    Console.Write(">>");
                    question.GivenAnswer = Console.ReadLine();
                    if (question.GivenAnswer.ToLower() == question.CorrectAnswer.ToLower()) {
                        question.Correct = true;
                    } else {
                        question.Correct = false;
                    }
                    Console.Clear();
                }         
            }
        }        
    }
    public class QuestionObject{
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Options { get; set; }
        public string GivenAnswer { get; set; }
        public bool Correct { get; set; }        
    }
    public class Quizard
    {
        private List<QuestionObject> m_Questions = new List<QuestionObject>();
        public List<QuestionObject> Questions {
            get { return m_Questions; }
            set {
                Questions = value;
            }
        }
        public string UserName { get; set; }
    }
