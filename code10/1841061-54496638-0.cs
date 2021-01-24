    char CorrAnswer = GetCorrectAnswer(int QuestionID);
    public bool CheckAnswer(char answer){
      if(answer.Equals(CorrAnswer)){
        return true;
      }
      else
        return false;
    }
    public void GetQuestion(){
      
    }
    
    public void ButtonClickForAnswer1(*some arguments here :D *){
      CheckAnswer('A')
    }
    public void ButtonClickForAnswer2(*some arguments here :D *){
      CheckAnswer('B')
    }
    public void ButtonClickForAnswer3(*some arguments here :D *){
      CheckAnswer('C')
    }
