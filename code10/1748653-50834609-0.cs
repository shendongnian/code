    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication51
    {
        class Program
        {
            public class Question
            {
                public int number { get; set; }
                public string question { get; set; }
                public string answer { get; set; }
                public List<string> wrongAnswer { get; set; }
            }
            static void Main(string[] args)
            {
                List<Question> test = new List<Question>() {
                    new Question() { number = 1, question = "Question 1", answer = "Answer 1", wrongAnswer = new List<string>() { "Wrong Answer 1","Wrong Answer 2","Wrong Answer 3"}},
                    new Question() { number = 2, question = "Question 2", answer = "Answer 2", wrongAnswer = new List<string>() { "Wrong Answer 1","Wrong Answer 2","Wrong Answer 3"}},
                    new Question() { number = 3, question = "Question 3", answer = "Answer 3", wrongAnswer = new List<string>() { "Wrong Answer 1","Wrong Answer 2","Wrong Answer 3"}},
                    new Question() { number = 4, question = "Question 4", answer = "Answer 4", wrongAnswer = new List<string>() { "Wrong Answer 1","Wrong Answer 2","Wrong Answer 3"}},
                    new Question() { number = 5, question = "Question 5", answer = "Answer 5", wrongAnswer = new List<string>() { "Wrong Answer 1","Wrong Answer 2","Wrong Answer 3"}}
                };
                Random rand = new Random();
                var results = test.OrderBy(x => x.number).Select(x => new List<KeyValuePair<int,string>>() { new KeyValuePair<int,string>(rand.Next(), x.answer), new KeyValuePair<int,string>(rand.Next(), x.wrongAnswer[0]),new KeyValuePair<int,string>(rand.Next(), x.wrongAnswer[1]),new KeyValuePair<int,string>(rand.Next(), x.wrongAnswer[2])})
                    .Select(x => x.OrderBy(y => y.Key).Select(y => y.Value).ToList()).ToList();
            }
        }
    }
