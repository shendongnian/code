    using System.Linq;
 
    void ShowQuestion()
    {
        RemoveAnswerButtons();
		ChooseQuestion(); // random question is succsessfull
		
        QuestionData questionData = questionPool[questionIndex];                            // Get the QuestionData for the current question
        questionText.text = questionData.questionText;                                      // Update questionText with the correct text
        Random rnd=new Random();
        var answersInRandomOrder = questionData.answers.OrderBy(x => rnd.Next()).ToArray();  
		
        for (int i = 0; i < answersInRandomOrder.Length; i++)                               // For every AnswerData in the current QuestionData...
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();         // Spawn an AnswerButton from the object pool
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObject.transform.localScale = Vector3.one;
            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.SetUp(answersInRandomOrder[i]);                                    // Pass the AnswerData to the AnswerButton so the AnswerButton knows what text to display and whether it is the correct answer
        }
    }   	
