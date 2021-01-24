        // assuming 10 questions
        var results = new bool[10];
        var correctAnswers = new string[10]; 
        var studAnswers = new string[10];
        
        for (int i; i < 10 ; i++)
        {
            if(studAnswer[i].ToLower() == correctAnswers[i].ToLower())
                results[i] = true;
    
    }
