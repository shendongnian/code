    private int a, b;
    [HideInInspector] public int answer;
    //varible whihc will assign ans to any one of the 4 answer button
    private int locationOfAnswer;
    //this methode perform Multiplication process
    void MultiplicationMethod()
    {
        bool reloop;
        int[] keeprandom = new int[ansButtons.Length];
        b = Random.Range(0, 10);
        locationOfAnswer = Random.Range(0, ansButtons.Length);
        answer = a * b;
        valueA.text = ("" + a).ToString();
        valueB.text = ("" + b).ToString(); ;
        mathSymbolObject.sprite = mathSymbols[0];
        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                keeprandom[i] = answer;
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {
                // the below code make sure that all the values assigned to the ans button are within the range
                int value = 0;
                do
                {
                    reloop = false;
                    if (a * b <= 30)
                    {
                        value = Random.Range(0, 30);
                    }
                    else if (a * b <= 60 & a * b >= 31)
                    {
                        value = Random.Range(28, 61);
                    }
                    else if (a * b <= 90 & a * b >= 61)
                    {
                        value = Random.Range(58, 91);
                    }
                    else if (a * b <= 120 & a * b >= 91)
                    {
                        value = Random.Range(88, 121);
                    }
                    else if (a * b <= 150 & a * b >= 121)
                    {
                        value = Random.Range(118, 151);
                    }
                    else if (a * b <= 200 & a * b >= 151)
                    {
                        value = Random.Range(148, 201);
                    }
                    keeprandom[i] = value;
                    if (i == 0)
                    {
                        break;
                    }
                    for (int j = 0; j < i; j++)
                    {
                        if (keeprandom[j] == value || value == answer)
                        {
                            reloop = true;
                            break;
                        }
                    }
                } while (reloop);
                ansButtons[i].GetComponentInChildren<Text>().text = "" + value;
            }
        }//for loop
    }
