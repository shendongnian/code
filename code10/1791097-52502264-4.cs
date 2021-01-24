    //Declare the array with answer
    string[] answers = { "True", "True", "True", "False", "True", "d", "c", "c", "a", "c" };
    
    string[] studentAnswer = new string[answers.Length];
    //You can use list
    List<string> incorrectAnswer = new List<string>();
    //Use the array in you while loop
    while (questionNum < questions.Length)
            {
                Console.WriteLine(questions[questionNum], 10, 30);
                //Here you store the student answer
                studentAnswer = Console.ReadLine();
                //Here you check the student answer using the same index of answer array
                if (studentAnswer.ToLower() == answers[answerNum].ToLower())
                {
                    Console.WriteLine("Correct!");
                    questionNum++;
                    answerNum++;
                    correctAnswer++;
                    qcounter++;
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                    incorrectAnswer.Add(studentAnswer)
                    //Remove these increment and the question will be the same in the next loop cycle
                    questionNum++; // remove
                    answerNum++; // remove
                    qcounter++; // remove
                }
                Console.WriteLine();
                Console.WriteLine("Press ENTER for Next question.");
                Console.ReadLine();
                Console.Clear();
            }
