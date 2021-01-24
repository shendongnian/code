        public static int solution(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                bool containsUpper = false;
                if (Char.IsLetter(s[i]))
                {
                    int len = 0;
                    do 
                    {
                        if (Char.IsUpper(s[i])){
                            containsUpper = true;
                        }
                        i++;
                        len++;
                        
                    } while (i<s.Length&&Char.IsLetter(s[i])) ;
                    if( (len > result )&&containsUpper)
                        result = len;
                }
              
            }
            return result;
        }
