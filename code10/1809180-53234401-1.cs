        private void OnAnswerSubmitted()
        {
            string currentQuestionId = ""; // however you get this in your UI.
            string selectedAnswer = "";
            
            if (_correctAnswerLookup[currentQuestionId] == selectedAnswer)
            {
                scoreCounter++;
            }
            lblScoreCounter.Text = scoreCounter.ToString();
        }
 
