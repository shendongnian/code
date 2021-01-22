    public double Dot2LongIP(string DottedIP)
    {
        int i;
        string [] arrDec;
        double num = 0;
        if (DottedIP == "")
        {
           return 0;
        }
        else
        {
           arrDec = DottedIP.Split('.');
           for(i = arrDec.Length - 1; i >= 0 ; i --)
           {
              num += ((int.Parse(arrDec[i])%256) * Math.Pow(256 ,(3 - i )));
           }
           return num;
        }
    }
