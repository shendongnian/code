    string test = "123,14.5,125,151,1.55,477,777,888";
    
    bool isParsingOk = true;
    
    
    int[] results = Array.ConvertAll<string,int>(test.Split(','), 
        new Converter<string,int>(
            delegate(string num)
            {
                int r;
                isParsingOk &= int.TryParse(num, out r);
                return r;
            }));
