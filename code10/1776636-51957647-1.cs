    string BadFunction()
    {
        return Globals.A + " " + Globals.B;  //Accessing global variables is confusing
    }
    string GoodFunction(string a, string b)
    {
        return a + " " + b;  //Clear, and also idempotent
    }
     
