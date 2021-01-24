    public void UserSelect(bool answer)
        {
            animator.SetTrigger(answer);
            if ((answer && currentQuestion.isTrue) || (!answer && !currentQuestion.isTrue) )
            {
                Debug.Log("CORRECT");
            } else
            {
                Debug.Log("WRONG");
            }
    
            StartCoroutine(TransistionToNextQuestion());
        }
