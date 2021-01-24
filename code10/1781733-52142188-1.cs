    private bool isExecuted = false;
    
    void DoesNothing(){}
    void OnlyCalledOnce(){
        if (!isExecuted)
        {   
            isExecuted = true;
            //lines of code
            DoesNothing();
        }
    }
