    public static SecureString ConvertStringToSecureString(this string data)
    {
         using(var secure = new SecureString())
         {
              foreach(var character in data.ToCharArray())
                   secure.AppendChar(character);
    
              secure.MakeReadOnly();
              return secure;
         }
    }
