    // Create new list to store all questions.
    var questions = new List<Question>();
    
    // Open file containing quiz questions using StreamReader, which allows you to read text from files easily.
    using (var quizFileReader = new System.IO.StreamReader("questions.txt"))
    {
        string line;
        Question question;
        // Loop through the lines of the file until there are no more (the ReadLine function return null at this point).
        // Note that the ReadLine called here only reads question texts (first line of a question), while other calls to ReadLine read the choices.
        while ((line = quizFileReader.ReadLine()) != null)
        {
            // Skip this loop if the line is empty.
            if (line.Length == 0)
                continue;
            // Create a new question object.
            // The "object initializer" construct is used here by including { } after the constructor to set variables.
            question = new Question()
            {
                // Set the question text to the line just read.
                QuestionText = line,
                // Set the choices to an array containing the next 4 lines read from the file.
                Choices = new string[]
                { 
                    quizFileReader.ReadLine(), 
                    quizFileReader.ReadLine(),
                    quizFileReader.ReadLine(),
                    quizFileReader.ReadLine()
                }
            };
            // Initially set the correct answer to -1, which means that no choice marked as correct has yet been found.
            question.Answer = -1;
            // Check each choice to see if it begins with the '!' char (marked as correct).
            for(int i = 0; i < 4; i++)
            {
                if (question.Choices[i].StartsWith("!"))
                {
                    // Current choice is marked as correct. Therefore remove the '!' from the start of the text and store the index of this choice as the correct answer.
                    question.Choices[i] = question.Choices[i].Substring(1);
                    question.Answer = i;
                    break; // Stop looking through the choices.
                }
            }
            // Check if none of the choices was marked as correct. If this is the case, we throw an exception and then stop processing.
            // Note: this is only basic error handling (not very robust) which you may want to later improve.
            if (question.Answer == -1)
            {
                throw new InvalidOperationException(
                    "No correct answer was specified for the following question.\r\n\r\n" + question.QuestionText);
            }
            // Finally, add the question to the complete list of questions.
            questions.Add(question);
        }
    }
