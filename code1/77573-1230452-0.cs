    //"name" represents a .net string data type containing the data to save  
    char[] textChars = new char[4000]; //4000 is the max varchar2 column size in Oracle  
    byte[] textBytes;  
    int index = 0;  
    textBytes = (System.Text.Encoding.Default.GetBytes((name).ToCharArray()));  
    foreach (byte textByte in textBytes)  
    {  
        textChars[index++] = (char)textByte;  
    }  
    string textString = new string(textChars, 0, index);  
    cmd.Parameters.Add(new OracleParameter(":name", (object)(textString)));  
  
  
