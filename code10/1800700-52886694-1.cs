    public string Encrypt(ref string passStr)
        {
            int pos, strLen, i, iValue;
            string returnValue;
            iValue = 100;
            strLen = passStr.Length;
            returnValue = "";
            for (i = 1; i <= strLen; i++)
            {
                pos = ((int)(Convert.ToChar(passStr.Substring(i, 1))) + (iValue + i));
                returnValue = returnValue + passStr[pos];
            }
            
            return returnValue;
        }
