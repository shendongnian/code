    string input="123456789";
    var pattern="XXX-XXX=XXX";
    
    var reg=new Regex(new string('N',input.Length).Replace("N","(\\w)"));//1.
    var regX=new Regex("X");
    for (int i = 1; i <= input.Length; i++)
    {
        pattern=regX.Replace(pattern,"$"+i.ToString(),1);//2.
    }
    Console.WriteLine( reg.Replace(input,pattern));
