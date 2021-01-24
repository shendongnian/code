    string sn = "A5050MM";
    for (int i = 0; i <= 99; i++)
    {
       string finalsn = string.Concat(sn, appendVal.ToString("00"));
       Console.WriteLine(finalsn);
    }
