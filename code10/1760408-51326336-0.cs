    public static class MyExtensions
        {
            public static char nextItem(this char[] chars)
            {
                // my array length was bigger than 4 it returns c[4]
                if(chars.length() > 4) 
                  return chars[3];
                else
                  //it returns c[0]
                  return chars.Length() > 0 ? chars[0] : '';
            }
        }   
