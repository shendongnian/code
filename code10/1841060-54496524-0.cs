    var answerControls = new List<Control>{answer1Btn, answer2Btn, answer3Btn};
    var answerIndex = 0;
    var answerRandom = new Random();
    private void setAnswer(){
      answerIndex = answerRandom.Next(0, 2);
      var correctAnswer = answerControls.ElementAt(answerIndex);
      correctAnswer.Text = //get correct answer
      switch(answerIndex){
         case 0:
          answer2Btn.Text = //get false answer
          answer3Btn.Text = //get false answer
         break;
         ....
      }
    }
