    //Declare the array with answer
    string[] answers = { "True", "True", "True", "False", "True", "d", "c", "c", "a", "c" };
    string[] studentAnswer = new string[answers.Length]; 
    //Use the array in you while loop
    while (questionNum < questions.Length)
            {
                Console.WriteLine(questions[questionNum], 10, 30);
                //Here you store the student answer
                studentAnswer[answerNum] = Console.ReadLine();
                //Here you check the student answer using the same index of answer array
                if (studentAnswer[answerNum] == answers[answerNum])
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
                    questionNum++;
                    answerNum++;
                    qcounter++;
                }
                Console.WriteLine();
                Console.WriteLine("Press ENTER for Next question.");
                Console.ReadLine();
                Console.Clear();
    
            }
