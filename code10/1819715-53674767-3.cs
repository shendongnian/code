    private int a, b;
    [HideInInspector] public int answer;
    //varible whihc will assign ans to any one of the 4 answer button
    private int locationOfAnswer;
    
    //this methode perform Multiplication process
    void MultiplicationMethod()
    {    
        bool reloop;
    	bool[]numbers = new bool[201];
    
        b = Random.Range(0, 10);
    
        locationOfAnswer = Random.Range(0, ansButtons.Length);
    
    
        answer = a * b;		
    	numbers[answer] = true;
    		
        valueA.text = ("" + a).ToString();
        valueB.text = ("" + b).ToString(); ;
    	
        mathSymbolObject.sprite = mathSymbols[0];
    
        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {
                // the below code make sure that all the values assigned to the ans button are within the range
    
                int value = 0;
                do
                {
                    reloop = false;
                    if (answer <= 30)
                    {
                        value = Random.Range(0, 30);
                    }
                    else if (answer <= 60 & answer >= 31)
                    {
                        value = Random.Range(28, 61);
                    }
                    else if (answer <= 90 & answer >= 61)
                    {
                        value = Random.Range(58, 91);
                    }
                    else if (answer <= 120 & answer >= 91)
                    {
                        value = Random.Range(88, 121);
                    }
                    else if (answer <= 150 & answer >= 121)
                    {
                        value = Random.Range(118, 151);
                    }
                    else if (answer <= 200 & answer >= 151)
                    {
                        value = Random.Range(148, 201);
                    }
    
    
                    if (numbers[value])	//already select?
                    {
                    	reloop = true;
                    }             
    
                } while (reloop);
    
    			numbers[value] = true;
                ansButtons[i].GetComponentInChildren<Text>().text = "" + value;
            }
    
        }//for loop
    }
