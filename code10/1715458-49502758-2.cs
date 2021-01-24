    public string myMethod()
    {
        int result = 0; //This must have a default value so in else part it is not unassigned when you return.
        int num2 = RandomNumberInt();
        bool isTrue = int.TryParse(userInputString, out int num1);
        if(isTrue)
        {
            //do something in result here
            return result.toString(); //This will return your in value as string
        }
        else
        {
            return "Your message as string" // This will return any string to provide for string return of the method
        }
    }
