    unsafe string Mine()
    {
       var temp = new string((char)0, Input.Length);
       var i = 0;
       fixed (char* pInput = Input, pTemp = temp)
       {
          var plen = pInput + Input.Length;
          *pTemp = *pInput;
               
          for (var pI = pInput + 1; pI < plen; pI++)
             if (*pI != *(pTemp+i))
                *(pTemp + ++i) = *pI;   
       }
    
       return temp.Substring(0,i+1);
    }
