    public double IPAddressToNumber(string IPaddress)
    {
        int i;
        string [] arrDec;
        double num = 0;
        if (IPaddress == "")
        {
            return 0;
        }
        else
        {
            arrDec = IPaddress.Split('.');
            for(i = arrDec.Length - 1; i >= 0 ; i = i -1)
                {
                    num += ((int.Parse(arrDec[i])%256) * Math.Pow(256 ,(3 - i )));
                }
            return num;
        }
    }
