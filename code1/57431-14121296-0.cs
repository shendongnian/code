    string myString = "abc";
    double num;
    bool isNumber = double.TryParse(myString , out num);
    if isNumber 
    {
	//string is number
    }
    else
    {
	//string is not a number
    }
