    public InputField input;
    
    void Start(){
        // Following line can be dismissed if we drag our input field in editor
        input = GameObject.Find("AnswerInputFieldName").GetComponent<InputField>();
    }
    
    void CheckAnswer(){
        string correct = "correctAnswer";
        string userAnswer = input.text;
        if(correct.compare(userAnswer) == 0)
            Debug.Log("That's correct!);
    }
