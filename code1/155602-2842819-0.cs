            Dictionary<Question,Answer> qDict = new Dictionary<Question, Answer>();
            Answer attempt_v2 = new Answer();
            Question question = new Question();
            if (qDict.ContainsKey(question))
            {
                Answer actual_answerv1 = qDict[question];
                if (actual_answerv1 == attempt_v2)
                {
                    // Answers match
                }
            }
