    public void Eval_String(string s)
    {
        string[] eachParam;
        eachParam = s.Split(',');
    
        if (eachParam.Length == 5)
        {
            //do something
            Console.WriteLine(eachParam[2]);
        }
    }
