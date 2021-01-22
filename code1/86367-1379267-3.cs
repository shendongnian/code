    public static string stepChar(string str)
    {
      return stepChar(str, str.Length - 1);
    }
    
    public static string stepChar(string str, int charPos)
    {
      return stepChar(Encoding.ASCII.GetBytes(str), charPos);
    }
    
    public static string stepChar(byte[] strBytes, int charPos)
    {
      //Escape case 
      if (charPos < 0)
      {
    	//just prepend with a and return
        return "a" + Encoding.ASCII.GetString(strBytes);
      }
      else
      {
         
        strBytes[charPos]++;
        
        if (strBytes[charPos] == 91)
        {
          //Z -> a plus increment previous char
          strBytes[charPos] = 97;
          return stepChar(strBytes, charPos - 1);                }
        else
        {
          if (strBytes[charPos] == 123)
          {
            //z -> A 
            strBytes[charPos] = 65;
          }
          
          return Encoding.ASCII.GetString(strBytes);
        }
      }
    }
