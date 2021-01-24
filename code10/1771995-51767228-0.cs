    public static int solution(string s)
    {
        int result=0; 
        for (int i = 0; i < s.Length; i++)
        {
            if(s[i].IsUpper(Z))
            {   
                int len=0;
                do(s[i].IsLower(Z))
                {
                    i++;
                    len++;
                 }while(s[i].IsLower(Z));
               if(len>result)
                 result=len;
            }
        }
       
        return result;
    }
