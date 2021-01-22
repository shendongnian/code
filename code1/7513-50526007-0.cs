    public static string HtmlEncode(string text)
        {
            if(text.length > 0){
               return HttpUtility.HtmlDecode(text);
            }else{
            
             return text;
            }
        }
