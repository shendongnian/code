    public void main()
    {
        Injection Time = new Injection();
    
        //Here is code that fills Time with Time values as string type
    
        string result = "";
        foreach(volt v in Time.volt)
        {
            foreach(string s in v.volts)
            {
               result += s + ";"
            }
        }
        Console.WriteLine(result);
    }
